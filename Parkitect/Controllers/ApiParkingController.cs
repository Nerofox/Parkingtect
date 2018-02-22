using bo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tools;

namespace Parkitect.Controllers
{
    [AllowAnonymous]
    public class ApiParkingController : Controller
    {
        const string API_PARKING = "http://data.citedia.com/r1/";

        // GET: ApiMap
        public async Task<string> List()
        {
            List<Parking> listParking = new List<Parking>();
            dynamic data = Api.Get(API_PARKING + "parks/?crs=EPSG:4326");
            //var data = result.parks[0].parkInformation.name.ToString();

            for (int i = 0; i < data.parks.Count; i++)
            {
                //create parking
                Parking newParking = new Parking();
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

                //add parking
                listParking.Add(newParking);
            }

            return JsonConvert.SerializeObject(listParking);
        }

        
    }
    
}