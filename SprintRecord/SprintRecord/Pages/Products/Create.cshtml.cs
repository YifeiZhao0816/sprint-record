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

        public CreateModel(SprintRecord.Models.SprintContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sprints Sprints { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sprints.Add(Sprints);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
