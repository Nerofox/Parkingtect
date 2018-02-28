using Newtonsoft.Json;
using Parkitect.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tools;
using bll;
using bo;

namespace Parkitect.Controllers
{
    public class ApiMapController : Controller
    {
        private const string API_MAPBOX = "https://api.mapbox.com/";
        const string API_PARKING = "http://data.citedia.com/r1/";
        private const string API_TOKEN = "pk.eyJ1IjoibmVyb2ZveCIsImEiOiJjamR1MDVnMXAyaGEwMnFxcGNvYWJ2cjByIn0.to1lq16P7bPjs0bUn4gUjg";

        public async Task<string> GetEvenementLocation(int id)
        {
            var evenementService = new EvenementService();
            var evenement = evenementService.Find(id);

            var str = (API_MAPBOX + "geocoding/v5/mapbox.places/" + evenement.Address + " " + evenement.City + ".json?access_token=" + API_TOKEN).Replace(" ", "%20");
            dynamic endPointString = Api.Get(str);

            return JsonConvert.SerializeObject(endPointString);
        }

        public async Task<string> GetParkingsEvenement(int id)
        {
            var evenementService = new EvenementService();
            var evenement = evenementService.Find(id);
            var str = (API_MAPBOX + "geocoding/v5/mapbox.places/" + evenement.Address + " " + evenement.City + ".json?access_token=" + API_TOKEN).Replace(" ", "%20");
            dynamic evenementLocation = Api.Get(str).features[0].geometry.coordinates;

            dynamic data = Api.Get(API_PARKING + "parks/?crs=EPSG:4326");
            var lon = Request.QueryString["lon"].Replace(",", ".");
            var lat = Request.QueryString["lat"].Replace(",", ".");

            List<Trajet> trajets = new List<Trajet>();
            for (int i = 0; i < data.parks.Count; i++)
            {
                for (int j = 0; j < data.features.features.Count; j++)
                {
                    dynamic oneElement = data.features.features[j];
                    if (oneElement.id.ToString() == data.parks[i].id.ToString())
                    {
                        var parkingLocation = oneElement.geometry.coordinates;
                        dynamic parkingInfo = new { Parking = data.parks[i], Location = parkingLocation };

                        trajets.Add(new Trajet(parkingInfo));

                        string urlDistance = API_MAPBOX + "directions/v5/mapbox/driving/" + lon + "," + lat + ";" + parkingLocation[0].ToString().Replace(",", ".") + "," + parkingLocation[1].ToString().Replace(",", ".") + "?access_token=" + API_TOKEN + "&geometries=geojson";
                        dynamic userToParking = Api.Get(urlDistance);
                        trajets[trajets.Count - 1].Duration += Convert.ToDouble(userToParking.routes[0].duration);
                        trajets[trajets.Count - 1].Distance += Convert.ToDouble(userToParking.routes[0].distance);
                        trajets[trajets.Count - 1].DrivingDirection = userToParking.routes[0].geometry;

                        urlDistance = API_MAPBOX + "directions/v5/mapbox/walking/" + evenementLocation[0].ToString().Replace(",", ".") + "," + evenementLocation[1].ToString().Replace(",", ".") + ";" + parkingLocation[0].ToString().Replace(",", ".") + "," + parkingLocation[1].ToString().Replace(",", ".") + "?access_token=" + API_TOKEN + "&geometries=geojson";
                        dynamic evtToParking = Api.Get(urlDistance);
                        trajets[trajets.Count - 1].Duration += Convert.ToDouble(evtToParking.routes[0].duration);
                        trajets[trajets.Count - 1].Distance += Convert.ToDouble(evtToParking.routes[0].distance);
                        trajets[trajets.Count - 1].WalkingDirection = evtToParking.routes[0].geometry;
                        break;
                    }
                }
            }

            var sortList = trajets.OrderBy(t => t.Distance).Take(3).Reverse();
            return JsonConvert.SerializeObject(sortList);
        }

        // GET: ApiMap
        public async Task<string> BestItiParking()
        {
            List<ParkingIti> list = new List<ParkingIti>();
            ApiParkingController apiPark = new ApiParkingController();
            dynamic data = Api.Get(API_PARKING + "parks/?crs=EPSG:4326");

            var lon = Request.QueryString["lon"].Replace(",", ".");
            var lat = Request.QueryString["lat"].Replace(",", ".");

            for (int i = 0; i < data.parks.Count; i++)
            {
                //create parking
                ParkingIti newParking = new ParkingIti();
                newParking.Id = data.parks[i].id.ToString();
                if (data.parks[i].parkInformation != null)
                {
                    newParking.Name = data.parks[i].parkInformation.name.ToString();
                    newParking.Status = data.parks[i].parkInformation.status.ToString();
                    newParking.FreePlace = Convert.ToInt32(data.parks[i].parkInformation.free.ToString());
                    newParking.MaxPlace = Convert.ToInt32(data.parks[i].parkInformation.max.ToString());
                }

                //search coordinate
                for (int j = 0; j < data.features.features.Count; j++)
                {
                    dynamic oneElement = data.features.features[j];
                    if (oneElement.id.ToString() == newParking.Id)
                    {
                        newParking.Geometry = oneElement.geometry;
                        break;
                    }
                }

                //search additional data by lon lat start
                lon = lon.Replace(",", ".");
                lat = lat.Replace(",", ".");
                string urlIti = API_MAPBOX + "directions/v5/mapbox/driving/" + lon + "," + lat + ";" + newParking.Geometry.coordinates[0].ToString().Replace(",", ".") + "," + newParking.Geometry.coordinates[1].ToString().Replace(",", ".") + "?access_token=" + API_TOKEN+ "&geometries=geojson";
                dynamic itiData = Api.Get(urlIti);
                newParking.GeometryIti = itiData.routes[0].geometry;
                newParking.Dist = Convert.ToDouble(itiData.routes[0].distance);
                newParking.TimeSecund = Convert.ToDouble(itiData.routes[0].duration);

                //add parking
                list.Add(newParking);
            }

            //sort by dist
            var sortList = list.OrderBy(l => l.Dist);


            return JsonConvert.SerializeObject(sortList);
        }
    }
}