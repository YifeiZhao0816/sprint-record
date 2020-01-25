using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SprintRecord.Models;

namespace SprintRecord.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public SprintContext dbContext { get; set; }
        


        public IndexModel(ILogger<IndexModel> logger, SprintContext context)
        {
            _logger = logger;
            dbContext = context;
        }

        public void OnGet()
        {
           
        }


    }
}
