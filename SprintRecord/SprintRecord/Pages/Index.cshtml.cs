using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SprintRecord.Models;
using SprintRecord.Services;

namespace SprintRecord.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger, JsonTeamService jsonTeamService)
        {
            _logger = logger;
        }

        public void OnGet()
        {
           
        }


    }
}
