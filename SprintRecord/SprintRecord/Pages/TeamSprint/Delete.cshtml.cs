using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SprintRecord.Models;

namespace SprintRecord
{
    public class DeleteModel : PageModel
    {
        private readonly SprintRecord.Models.SprintContext _context;

        public DeleteModel(SprintRecord.Models.SprintContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamSprint = await _context.TeamSprint.FindAsync(id);

            if (TeamSprint != null)
            {
                _context.TeamSprint.Remove(TeamSprint);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
