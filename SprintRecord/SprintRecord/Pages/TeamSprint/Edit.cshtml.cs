using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SprintRecord.Models;

namespace SprintRecord
{
    public class EditModel : PageModel
    {
        private readonly SprintRecord.Models.SprintContext _context;

        public EditModel(SprintRecord.Models.SprintContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TeamSprint TeamSprint { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamSprint = await _context.TeamSprint.FirstOrDefaultAsync(m => m.Id == id);

            if (TeamSprint == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TeamSprint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamSprintExists(TeamSprint.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TeamSprintExists(int id)
        {
            return _context.TeamSprint.Any(e => e.Id == id);
        }
    }
}
