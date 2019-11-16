using Microsoft.AspNetCore.Hosting;
using SprintRecord.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SprintRecord.Services
{
    public class JsonSprintService
    {
        public JsonSprintService(IWebHostEnvironment webHostEnvironment) 
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get;  }
        public string getJsonPath()
        {
            return Path.Combine(WebHostEnvironment.WebRootPath, "sampledata.json");
        }

        public IEnumerable<SprintWeek> GetSprintWeeks()
        {
            using (var jsonFileReader = File.OpenText(getJsonPath()))
            {
                return JsonSerializer.Deserialize<SprintWeek[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ;
            }
        }


    }
}
