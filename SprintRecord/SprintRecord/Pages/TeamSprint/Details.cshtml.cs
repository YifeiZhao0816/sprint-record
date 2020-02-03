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
    public class DetailsModel : PageModel
    {
        private readonly SprintRecord.Models.SprintContext _context;

        public DetailsModel(SprintRecord.Models.SprintContext context)
        {
            _context = context;
        }

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
    }
}
