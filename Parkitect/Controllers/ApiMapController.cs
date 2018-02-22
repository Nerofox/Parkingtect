using Newtonsoft.Json;
using Parkitect.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Parkitect.Controllers
{
    public class ApiMapController : Controller
    {
        private const string API_MAPBOX = "https://api.mapbox.com/";
        private const string API_TOKEN = "pk.eyJ1IjoibmVyb2ZveCIsImEiOiJjamR1MDVnMXAyaGEwMnFxcGNvYWJ2cjByIn0.to1lq16P7bPjs0bUn4gUjg";

        // GET: ApiMap
        public async Task<string> BestItiParking()
        {
            ApiParkingController apiPark = new ApiParkingController();
            List<ParkingIti> list = JsonConvert.DeserializeObject<List<ParkingIti>>(apiPark.List());

            var lon = Request.QueryString["lon"];
            var lat = Request.QueryString["lat"];

            return JsonConvert.SerializeObject(list);
        }
    }
}