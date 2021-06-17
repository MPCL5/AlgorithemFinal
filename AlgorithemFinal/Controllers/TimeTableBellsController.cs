using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlgorithemFinal.Models;
using AlgorithemFinal.Utiles.Extensions;
using AlgorithemFinal.Models.Requests;
using AlgorithemFinal.Utiles.Pagination;

namespace AlgorithemFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTableBellsController : ControllerExtension
    {
        private readonly AfDbContext _context;

        public TimeTableBellsController(AfDbContext context)
        {
            _context = context;
        }

        // GET: api/TimeTableBells
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<TimeTableBell>>> GetTimeTableBells(
                [FromQuery] PaginationParams pagination
            )
        {
            // return await _context.TimeTableBells.ToListAsync();
            return Ok();
        }

        // GET: api/TimeTableBells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeTableBell>> GetTimeTableBell(int id)
        {
            var timeTableBell = await _context.TimeTableBells.FindAsync(id);

            if (timeTableBell == null)
            {
                return NotFound();
            }

            return timeTableBell;
        }

        // PUT: api/TimeTableBells/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTimeTableBell(int id, [FromBody] TimeTableBellRequest timeTableBell)
        //{
        //    //if (id != timeTableBell.Id)
        //    //{
        //    //    return BadRequest();
        //    //}

        //    _context.Entry(timeTableBell).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TimeTableBellExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/TimeTableBells
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TimeTableBell>> PostTimeTableBell([FromBody] TimeTableBellRequest timeTableBell)
        {
            //_context.TimeTableBells.Add(timeTableBell);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTimeTableBell", new { id = timeTableBell.Id }, timeTableBell);
            return Ok();
        }

        // DELETE: api/TimeTableBells/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeTableBell(int id)
        {
            var timeTableBell = await _context.TimeTableBells.FindAsync(id);
            if (timeTableBell == null)
            {
                return NotFound();
            }

            _context.TimeTableBells.Remove(timeTableBell);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeTableBellExists(int id)
        {
            return _context.TimeTableBells.Any(e => e.Id == id);
        }
    }
}
