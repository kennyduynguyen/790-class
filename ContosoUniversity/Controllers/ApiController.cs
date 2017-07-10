using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ContosoUniversity.Models;
using System.Web.Script.Serialization;

namespace ContosoUniversity.Controllers
{
    public class ApiController : Controller
    {
        static string _address = "http://www.txsmartbuy.com/api/items?include=facets&fieldset=search&language=en&country=US&currency=USD&pricelevel=5&custitem_exclude_from_search_results=false&sort=custitem_preferred_term%3Aasc&limit=50&offset=0&q=";
        static List<object> _result = new List<object>();

        public async Task<List<Object>> Search(string searchString, int fetchNumber)
        {
            var json = await GetExternalResponse(searchString);
            dynamic item = JsonConvert.DeserializeObject(json);

            // Store the number of items in a List to pass over the view
            List<object> result = new List<object>();
            for (var i = 0; i < fetchNumber; i++ )
            {
                result.Add(item.items[i]);
            }
            return result;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string searchString, int fetchNumber)
        {
            _result = await Search(searchString, fetchNumber);
            return RedirectToAction("Display");
        }

        public ActionResult Display()
        {
            ViewBag.items = _result;
            return View();
        }

        private async Task<string> GetExternalResponse(string searchString)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_address + searchString);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}