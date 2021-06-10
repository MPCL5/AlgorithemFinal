﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlgorithemFinal.Models;
using AlgorithemFinal.Utiles.Extensions;
using AlgorithemFinal.Utiles.Pagination;

namespace AlgorithemFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTablesController : ControllerExtension
    {
        private readonly AfDbContext _context;

        public TimeTablesController(AfDbContext context)
        {
            _context = context;
        }

        
        // GET: api/TimeTables
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<TimeTable>>> GetTimeTables([FromQuery] PaginationParams pagination)
        {
            // await _context.TimeTables.ToListAsync();
            return Ok();
        }

        /// <summary>
        /// با این Api قراره فقط حال کنیم
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/TimeTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeTable>> GetTimeTable(int id)
        {
            var timeTable = await _context.TimeTables.FindAsync(id);

            if (timeTable == null)
            {
                return NotFound();
            }

            return timeTable;
        }

        // PUT: api/TimeTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeTable(int id, TimeTable timeTable)
        {
            if (id != timeTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(timeTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeTableExists(id))
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

        // POST: api/TimeTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TimeTable>> PostTimeTable(TimeTable timeTable)
        {
            _context.TimeTables.Add(timeTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeTable", new { id = timeTable.Id }, timeTable);
        }

        // DELETE: api/TimeTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeTable(int id)
        {
            var timeTable = await _context.TimeTables.FindAsync(id);
            if (timeTable == null)
            {
                return NotFound();
            }

            _context.TimeTables.Remove(timeTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeTableExists(int id)
        {
            return _context.TimeTables.Any(e => e.Id == id);
        }
    }
}
