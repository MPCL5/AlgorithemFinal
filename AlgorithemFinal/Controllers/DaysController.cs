using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlgorithemFinal.Models;
using AlgorithemFinal.Models.Requests;
using AlgorithemFinal.Utiles.Extensions;
using AlgorithemFinal.Utiles.Pagination;

namespace AlgorithemFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerExtension
    {
        private readonly AfDbContext _context;

        public DaysController(AfDbContext context)
        {
            _context = context;
        }

        // GET: api/Days
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<Day>>> GetDays(
                [FromQuery] PaginationParams pagination
            )
        {
            //return await _context.Days.ToListAsync();
            return Ok();
        }

        // GET: api/Days/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Day>> GetDay(int id)
        {
            var day = await _context.Days.FindAsync(id);

            if (day == null)
            {
                return NotFound();
            }

            return day;
        }

        // PUT: api/Days/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDay(int id, [FromBody] DayRequest day)
        {
            //if (id != day.Id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(day).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayExists(id))
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

        // POST: api/Days
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Day>> PostDay([FromBody] DayRequest day)
        {
            //_context.Days.Add(new Day() { DayOfWeek});
            //await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Days/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDay(int id)
        {
            var day = await _context.Days.FindAsync(id);
            if (day == null)
            {
                return NotFound();
            }

            _context.Days.Remove(day);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayExists(int id)
        {
            return _context.Days.Any(e => e.Id == id);
        }
    }
}
