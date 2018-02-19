using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Parkitect.Controllers
{
    public class ApiMapController : Controller
    {
        const string API_PARKING = "http://data.citedia.com/r1/";

        // GET: ApiMap
        /*public async ActionResult ListParking()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(API_PARKING+ "parks/?crs=EPSG:4326");

            return View();
        }*/
    }
}