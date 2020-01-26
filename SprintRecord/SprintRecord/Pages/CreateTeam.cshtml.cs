using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SprintRecord.Models;

namespace SprintRecord
{
    public class CreateTeamModel : PageModel
    {
        public void OnGet()
        {

        }

        public SprintContext Context { get; set; }
        [BindProperty]
        public Teams NewTeam { get; set; }

        public CreateTeamModel(SprintContext context)
        {
            Context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Context.Teams.Add(NewTeam);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}