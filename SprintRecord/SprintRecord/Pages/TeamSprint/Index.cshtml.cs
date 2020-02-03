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
    public class IndexModel : PageModel
    {
        private readonly SprintRecord.Models.SprintContext _context;

        public IndexModel(SprintRecord.Models.SprintContext context)
        {
            _context = context;
        }

        public IList<TeamSprint> TeamSprint { get;set; }

        public async Task OnGetAsync()
        {
            TeamSprint = await _context.TeamSprint.ToListAsync();
        }
    }
}
