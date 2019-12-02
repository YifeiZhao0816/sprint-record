using Microsoft.AspNetCore.Hosting;
using SprintRecord.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SprintRecord.Services
{
    public class JsonTeamService
    {
        public JsonTeamService(IWebHostEnvironment webHostEnvironment) 
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get;  }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "sampledata.json"); }
        }

        public IEnumerable<Team> GetTeams()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Team[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ;
            }
        }

        public void StoreTeamsData(IEnumerable<Team> teams)
        {
            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions

                    {

                        SkipValidation = false,

                        Indented = true

                    }),
                    teams
                );
            }
        }

    }
}
