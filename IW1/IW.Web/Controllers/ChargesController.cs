using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IW.Web.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
//using IW.CalculateCharges;

namespace IW.Web.Controllers
{
    public class ChargesController : Controller
    {
        private IHostingEnvironment _env;
        public ChargesController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public JsonResult GetCustomerCharges(string data)
        {
            var webRoot = _env.WebRootPath;
            var datafile = webRoot + @"\data\Job1.json";
            var file = System.IO.Path.Combine(webRoot, datafile);
            JObject jobj = LoadJson(file);

            //IList<PrintJobViewModel> viewModel = jobj.Select(p => new PrintJobViewModel
            //{
            //    JobName = (string)p["JobName"],
            //    JobType = (string)p["Author"]["Name"],
            //}).ToList();

            //var viewModel =
           

            return Json(viewModel);
        }

        public static JObject LoadJson(string fileName)
        {
            //List<PrintJobViewModel> jobs = new List<PrintJobViewModel>();
            if (!System.IO.File.Exists(fileName)) { return null; }

            using (StreamReader file = System.IO.File.OpenText(fileName)) 
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject jobj = (JObject)JToken.ReadFrom(reader);
                return jobj;
            }
        }

        public async void CallApi(Object stateInfo)
        {
            var client = new HttpClient();
            var requestContent = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("pair", "XETHZEUR"), });
            HttpResponseMessage response = await client.PostAsync("https://api.kraken.com/0/public/Trades", requestContent);
            HttpContent responseContent = response.Content;
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                String result = await reader.ReadToEndAsync();
                var vm = JsonConvert.DeserializeObject(result);
            }
        }
    }
}