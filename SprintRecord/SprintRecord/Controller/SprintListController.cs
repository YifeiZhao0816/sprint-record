using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SprintRecord.Models;

namespace SprintRecord.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintListController : ControllerBase
    {
        private readonly SprintContext _context;

        public SprintListController(SprintContext context)
        {
            _context = context;
        }

        // GET: api/Sprints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sprints>>> GetSprints()
        {
            return await _context.Sprints.ToListAsync();
        }

        // GET: api/Sprints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sprints>> GetSprints(int id)
        {
            var sprints = await _context.Sprints.FindAsync(id);

            if (sprints == null)
            {
                return NotFound();
            }

            return sprints;
        }

        // PUT: api/Sprints/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSprints(int id, Sprints sprints)
        {
            if (id != sprints.Id)
            {
                return BadRequest();
            }

            _context.Entry(sprints).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SprintsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sprints
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Sprints>> PostSprints(Sprints sprints)
        {
            _context.Sprints.Add(sprints);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSprints", new { id = sprints.Id }, sprints);
        }

        // DELETE: api/Sprints/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sprints>> DeleteSprints(int id)
        {
            var sprints = await _context.Sprints.FindAsync(id);
            if (sprints == null)
            {
                return NotFound();
            }

            _context.Sprints.Remove(sprints);
            await _context.SaveChangesAsync();

            return sprints;
        }

        private bool SprintsExists(int id)
        {
            return _context.Sprints.Any(e => e.Id == id);
        }
    }
}
