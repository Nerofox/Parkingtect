using System.Net.Http;
using System.Web.Mvc;
using bo;
using bll;
using Tools;

namespace Parkitect.Controllers
{  [Authorize]

    public class ApiRouteController : Controller
    {
        static HttpClient client = new HttpClient();
        const string API_ROUTE = "https://api.mapbox.com/";
        const string TOKEN = "?access_token=pk.eyJ1IjoibmVyb2ZveCIsImEiOiJjamR1MDVnMXAyaGEwMnFxcGNvYWJ2cjByIn0.to1lq16P7bPjs0bUn4gUjg";

        public dynamic getRoutePlan(int id)
        {
            EvenementService EventService = new EvenementService();
            Evenement endPoint = EventService.Find(id);

            string startPointString = "-73.989,40.733";

            dynamic endPointString = Api.Get(API_ROUTE + "/geocoding/v5/mapbox.places-permanen/" + endPoint.Address + ".json" + TOKEN);            
            dynamic data = Api.Get(API_ROUTE + "/geocoding/v5/mapbox.driving-traffic/" + startPointString + ";" + endPointString + ".json" + TOKEN);

            return data;
        }
    }
}
