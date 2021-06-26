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
    public class BellsController : ControllerExtension
    {
        private readonly AfDbContext _context;

        public BellsController(AfDbContext context)
        {
            _context = context;
        }

        // GET: api/Bells
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<Bell>>> GetBells(
            [FromQuery] PaginationParams pagination
        )
        {
            var data = _context.Bells.AsNoTracking();
            var result = await PaginatedList<Bell>.CreateAsync(data, pagination);

            return Ok(result.Result);
        }

        // GET: api/Bells/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Bell>> GetBell(int id)
        {
            var bell = await _context.Bells.FindAsync(id);

            return bell == null ? NotFound() : Ok(bell);
        }

        // PUT: api/Bells/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutBell(int id, [FromBody] BellRequest model)
        {
            var bell = _context.Bells.FirstOrDefault(item => item.Id == id);

            if (bell == null) return NotFound();

            if (model.Label != null)
                bell.Label = model.Label;
            if (model.BellOfDay != null)
                bell.BellOfDay = model.BellOfDay.GetValueOrDefault();

            _context.Bells.Update(bell);
            await _context.SaveChangesAsync();

            return Ok(bell);
        }

        // POST: api/Bells
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpPost]
        public async Task<ActionResult<Bell>> PostBell([FromBody] BellRequest model)
        {
            //_context.Bells.Add(bell);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetBell", new { id = bell.Id }, bell);
            var validationErrors = new List<ValidationError>();

            if (model.Label == null)
                validationErrors.Add(new ValidationError
                    {Field = nameof(model.Label), Message = "برچسب اجباری میباشید."});
            if (model.BellOfDay == null)
                validationErrors.Add(new ValidationError
                    {Field = nameof(model.BellOfDay), Message = "زنگ در روز اجباری میباشد."});

            if (validationErrors.Count != 0) return BadRequest(validationErrors);

            var bell = new Bell {Label = model.Label, BellOfDay = model.BellOfDay.GetValueOrDefault()};
            _context.Bells.Add(bell);
            await _context.SaveChangesAsync();

            return Ok(bell);
        }

        // DELETE: api/Bells/5
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBell(int id)
        {
            var bell = await _context.Bells.FindAsync(id);
            if (bell == null) return NotFound();

            _context.Bells.Remove(bell);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}