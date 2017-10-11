using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IW.Api.Core
{
    public class ReadJson
    {
        public static JObject LoadJson(string fileName)
        {
            if (!System.IO.File.Exists(fileName)) { return null; }

            using (StreamReader file = System.IO.File.OpenText(fileName))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject jobj = (JObject)JToken.ReadFrom(reader);
                return jobj;
            }
        }
    }
}
