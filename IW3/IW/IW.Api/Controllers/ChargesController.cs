using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using IW.Api.Core;
using Newtonsoft.Json.Linq;

namespace IW.Api.Controllers
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
        public IEnumerable<string> Get()
        {
            var webRoot = _env.WebRootPath;
            var datafile = webRoot + @"\data\Job1.json";
            var file = System.IO.Path.Combine(webRoot, datafile);
            JObject jobj = ReadJson.LoadJson(file);


            return new string[] { "value1", "value2" };
        }

        // GET: api/Charges/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
