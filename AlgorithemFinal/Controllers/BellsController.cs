using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlgorithemFinal.Models;

namespace AlgorithemFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BellsController : ControllerBase
    {
        private readonly AfDbContext _context;

        public BellsController(AfDbContext context)
        {
            _context = context;
        }

        // GET: api/Bells
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bell>>> GetBells()
        {
            return await _context.Bells.ToListAsync();
        }

        // GET: api/Bells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bell>> GetBell(int id)
        {
            var bell = await _context.Bells.FindAsync(id);

            if (bell == null)
            {
                return NotFound();
            }

            return bell;
        }

        // PUT: api/Bells/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBell(int id, Bell bell)
        {
            if (id != bell.Id)
            {
                return BadRequest();
            }

            _context.Entry(bell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BellExists(id))
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

        // POST: api/Bells
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bell>> PostBell(Bell bell)
        {
            _context.Bells.Add(bell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBell", new { id = bell.Id }, bell);
        }

        // DELETE: api/Bells/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBell(int id)
        {
            var bell = await _context.Bells.FindAsync(id);
            if (bell == null)
            {
                return NotFound();
            }

            _context.Bells.Remove(bell);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BellExists(int id)
        {
            return _context.Bells.Any(e => e.Id == id);
        }
    }
}
