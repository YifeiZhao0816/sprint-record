using SprintRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SprintRecord.Services
{
    public class SprintService
    {
        public SprintContext Context { get; set; }
        public SprintService(SprintContext context) 
        {
            Context = context;
        }


    }
}
