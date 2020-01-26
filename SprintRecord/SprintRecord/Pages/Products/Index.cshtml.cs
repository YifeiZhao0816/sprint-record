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

        public IList<Sprints> Sprints { get;set; }

        public async Task OnGetAsync()
        {
            Sprints = await _context.Sprints.ToListAsync();
        }

    }
}
