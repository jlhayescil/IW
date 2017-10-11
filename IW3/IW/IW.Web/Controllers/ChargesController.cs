using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using IW.Web.Core;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace IW.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Charges")]
    public class ChargesController : Controller
    {
        private IHostingEnvironment _env;
        public ChargesController(IHostingEnvironment env)
        {
            _env = env;
        }

        // GET: api/Charges
        [HttpGet]
        public List<PrintJob> GetCharges()
        {
            var webRoot = _env.WebRootPath;
            var datafile = webRoot + @"\data\PrintJobs.json";
            var file = System.IO.Path.Combine(webRoot, datafile);

            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                List<PrintJob> items = JsonConvert.DeserializeObject<List<PrintJob>>(json);
                return items;
            }
           
        }

        // GET: api/Charges/5
        [HttpGet("{id}", Name = "Get")]
        public List<PrintJob> Get(int id)
        {
            var webRoot = _env.WebRootPath;
            var datafile = webRoot + @"\data\PrintJobs.json";
            var file = System.IO.Path.Combine(webRoot, datafile);

            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                List<PrintJob> jobs = JsonConvert.DeserializeObject<List<PrintJob>>(json);

                foreach (PrintJob j in jobs)
                {
                    CalculateCharges.CalculateCustCharges(j);
                }
                return jobs;
            }
        }
        
        // POST: api/Charges
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Charges/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

