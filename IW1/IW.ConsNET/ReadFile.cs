using CalculateCharges;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IW.ConsNET
{
    public class ReadFile
    {
        public static PrintJob LoadJson(string filename)
        {
            List<PrintJob> jobs = new List<PrintJob>();
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                var job = JsonConvert.DeserializeObject<PrintJob>(json);
                
                return job;
            }
        }

    }
}
