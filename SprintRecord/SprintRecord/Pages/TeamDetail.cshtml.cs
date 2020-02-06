using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [BindProperty]
        public int[] SelectedDevelopers { get; set; }
        public SelectList AllDevelopers { get; set; }

        public TeamDetailModel(SprintContext context, SprintService sprintService)
        {
            Context = context;
            SprintService = sprintService;
        }
        public void OnGet(int id)
        {
            TeamDetail = SprintService.GetTeamStatus(id);
            AllDevelopers = new SelectList(Context.Developers.ToList().FindAll(d => !TeamDetail.Developers.ToList().Exists(td => td.Id == d.Id)), nameof(Developers.Id), nameof(Developers.Name));
            RandomDebugStuff.MyProperty = id;
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

        public async Task<IActionResult> OnPostTestAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach (int devId in SelectedDevelopers)
            {
                Context.TeamDeveloper.Add(new TeamDeveloper { Teamid = RandomDebugStuff.MyProperty, Developerid = devId });
            }
            Context.SaveChanges();


            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            SprintService.DeleteTeam(RandomDebugStuff.MyProperty);
            return RedirectToPage("./Index");
        }

    }
}