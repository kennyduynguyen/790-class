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
        static string _address = "http://www.txsmartbuy.com/api/items?include=facets&fieldset=search&language=en&country=US&currency=USD&pricelevel=5&custitem_exclude_from_search_results=false&sort=custitem_preferred_term%3Aasc&limit=50&offset=0&q=paper%2Ctowel";

        public async Task<ActionResult> Index()
        {
            var json = await Get();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic item = JsonConvert.DeserializeObject(json);
            // var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductItems>>(json);
            ViewBag.item = item.items[1];
            return View();
        }

        public async Task<string> Get()
        {
            var result = await GetExternalResponse();
            return result;
        }

        private async Task<string> GetExternalResponse()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_address);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}