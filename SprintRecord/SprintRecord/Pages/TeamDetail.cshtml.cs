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
    public class TeamDetailModel : PageModel
    {
        public TeamStatus TeamDetail { get; set; }
        public SprintContext Context { get; set; }
        public SprintService SprintService { get; set; }
        public TeamDetailModel(SprintContext context, SprintService sprintService)
        {
            Context = context;
            SprintService = sprintService;
        }
        public void OnGet(int id)
        {
            TeamDetail = SprintService.GetTeamStatus(id);
        }
    }
}