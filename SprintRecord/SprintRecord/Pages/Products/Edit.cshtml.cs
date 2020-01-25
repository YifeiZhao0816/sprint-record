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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sprints).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SprintsExists(Sprints.Id))
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

        private bool SprintsExists(int id)
        {
            return _context.Sprints.Any(e => e.Id == id);
        }
    }
}
