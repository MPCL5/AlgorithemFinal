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
using AlgorithemFinal.Utiles;
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
        [Authorize(Policy = new []{nameof(Master), nameof(Admin)})]
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<TimeTableBell>>> GetTimeTableBells(
                [FromQuery] PaginationParams pagination
            )
        {
            var user = (User) HttpContext.Items["User"];

            var result = _context.TimeTableBells.AsNoTracking();

            result = result
                .Include(item => item.Day)
                .Include(item => item.Bell);
                // .Include(item => item.Master);

                if (user.Role == nameof(Master).ToLower())
                    result = result.Where(item => item.MasterId == user.Master.Id);
                else
                    result = result.Include(item => item.Master.User);

            var data = await PaginatedList<TimeTableBell>.CreateAsync(result, pagination);
            
            return Ok(data.Result);
        }

        // GET: api/TimeTableBells/5
        [HttpGet("{id:int}")]
        [Authorize(Policy = new []{nameof(Master), nameof(Admin)})]
        public async Task<ActionResult<TimeTableBell>> GetTimeTableBell(int id)
        {
            var timeTableBell = _context.TimeTableBells.AsNoTracking()
                .Where(item => item.Id == id)
                .Include(item => item.Master.User)
                .Select(item => new
                {
                    Id = item.Id,
                    Day = item.Day,
                    Bell = item.Bell,
                    Master = item.Master,
                    TimeTable = item.TimeTable
                });

            return timeTableBell == null ? NotFound() : Ok(timeTableBell);
        }

        // POST: api/TimeTableBells
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = new []{nameof(Master)})]
        public async Task<ActionResult<TimeTableBell>> PostTimeTableBell([FromBody] TimeTableBellRequest model)
        {
            var validationErrors = new List<ValidationError>();

            if (model.BellId == null)
                validationErrors.Add(new ValidationError
                    {Field = nameof(model.BellId), Message = "زنگ اجباری میباشید."});
            if (model.DayId == null)
                validationErrors.Add(new ValidationError
                    {Field = nameof(model.DayId), Message = "روز اجباری میباشید."});

            if (validationErrors.Count != 0)
                return BadRequest(validationErrors);

            var day = await _context.Days.FirstOrDefaultAsync(item => item.Id == model.DayId);
            var bell = await _context.Bells.FirstOrDefaultAsync(item => item.Id ==model.BellId);

            if (day == null)
                validationErrors.Add(new ValidationError
                    {Field = nameof(model.DayId), Message = "روز موجود نمیباشید."});

            if (bell == null)
                validationErrors.Add(new ValidationError
                    {Field = nameof(model.BellId), Message = "زنگ موجود نمیباشید."});
            
            if (validationErrors.Count != 0)
                return BadRequest(validationErrors);

            var user = (User) HttpContext.Items["User"];

            var newData = new TimeTableBell { Bell = bell, Day = day, Master = user.Master};
            _context.TimeTableBells.Update(newData);

            await _context.SaveChangesAsync();
            
            return Ok(newData);
        }

        // DELETE: api/TimeTableBells/5
        [Authorize(Policy = new []{nameof(Master), nameof(Admin)})]
        [HttpDelete("{id:int}")]
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
    }
}
