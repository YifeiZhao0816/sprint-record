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
        [BindProperty]
        public Developers NewDeveloper { get; set; }
        public bool Test { get; set; }

        public TeamDetailModel(SprintContext context, SprintService sprintService)
        {
            Context = context;
            SprintService = sprintService;
            Test = false;
        }
        public void OnGet(int id)
        {
            TeamDetail = SprintService.GetTeamStatus(id);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Context.Developers.Add(NewDeveloper);
            await Context.SaveChangesAsync();
            

            return RedirectToPage();
        }

    }
}