using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SprintRecord.Models;

namespace SprintRecord
{
    public class CreateModel : PageModel
    {
        private readonly SprintRecord.Models.SprintContext _context;
        public SelectList TeamSelector { get; set; }
        public SelectList SprintSelector { get; set; }

        public CreateModel(SprintRecord.Models.SprintContext context)
        {
            _context = context;
            TeamSelector = new SelectList(_context.Teams.ToList(), nameof(Teams.Id), nameof(Teams.Name));
            SprintSelector = new SelectList(_context.Sprints.ToList(), nameof(Sprints.Id), nameof(Sprints.Name));
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TeamSprint TeamSprint { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TeamSprint.Add(TeamSprint);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
