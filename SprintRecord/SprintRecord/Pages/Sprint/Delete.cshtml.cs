using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SprintRecord.Models;

namespace SprintRecord.SprintViews
{
    public class DeleteModel : PageModel
    {
        private readonly SprintRecord.Models.SprintContext _context;

        public DeleteModel(SprintRecord.Models.SprintContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sprints Sprints { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sprints = await _context.Sprints.FirstOrDefaultAsync(m => m.Id == id);

            if (Sprints == null)
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

            Sprints = await _context.Sprints.FindAsync(id);

            if (Sprints != null)
            {
                _context.Sprints.Remove(Sprints);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
