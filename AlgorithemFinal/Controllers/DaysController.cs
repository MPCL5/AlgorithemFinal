using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgorithemFinal.Models;
using AlgorithemFinal.Models.Requests;
using AlgorithemFinal.Utiles;
using AlgorithemFinal.Utiles.Extensions;
using AlgorithemFinal.Utiles.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var result = _context.Days.AsNoTracking();
            var resultFinal = await PaginatedList<Day>.CreateAsync(result, pagination);

            return Ok(resultFinal.Result);
        }

        // GET: api/Days/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Day>> GetDay(int id)
        {
            var day = await _context.Days.FindAsync(id);

            return day == null ? NotFound() : Ok(day);
        }

        // PUT: api/Days/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutDay(int id, [FromBody] DayRequest model)
        {
            var day =  await _context.Days.FindAsync(id);

            if (day == null)
                return NotFound();

            if (model.Label != null)
                day.Label = model.Label;
            if (model.DayOfWeek.HasValue)
                day.DayOfWeek = model.DayOfWeek.GetValueOrDefault();

            _context.Days.Update(day);
            await _context.SaveChangesAsync();

            return Ok(day);
        }

        // POST: api/Days
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpPost]
        public async Task<ActionResult<Day>> PostDay([FromBody] DayRequest model)
        {
            var validationErrors = new List<object>();

            if (model.Label == null)
                validationErrors.Add(new ValidationError
                    {Field = nameof(model.Label), Message = "برچسب اجباری میباشید."});
            if (model.DayOfWeek == null)
                validationErrors.Add(new ValidationError
                    {Field = nameof(model.DayOfWeek), Message = "روز هفته اجباری میباشید."});

            if (validationErrors.Count != 0)
                return BadRequest(validationErrors);

            var dayToAdd = new Day {Label = model.Label, DayOfWeek = model.DayOfWeek.GetValueOrDefault()};
            _context.Days.Add(dayToAdd);

            await _context.SaveChangesAsync();

            return Ok(dayToAdd);
        }

        // DELETE: api/Days/5
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDay(int id)
        {
            var day = await _context.Days.FindAsync(id);
            if (day == null) return NotFound();

            _context.Days.Remove(day);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}