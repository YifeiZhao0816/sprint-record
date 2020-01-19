using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SprintRecord.Models
{
    public class SprintDbContext: DbContext
    {
        public SprintDbContext(DbContextOptions<SprintDbContext> options)
        : base(options)
        { }

        public DbSet<Developer> Developers { get; set; }
        
    }
}
