using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlgorithemFinal.Models;
using AlgorithemFinal.Utiles;
using AlgorithemFinal.Models.Requests;
using AlgorithemFinal.Utiles.Extensions;
using AlgorithemFinal.Utiles.Pagination;

namespace AlgorithemFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerExtension
    {
        private readonly AfDbContext _context;

        public AnnouncementsController(AfDbContext context)
        {
            _context = context;
        }

        // GET: api/Announcements
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<Announcement>>> GetAnnouncements(
                [FromQuery] int? MasterId,
                [FromQuery] int? TimeTableId,
                [FromQuery] PaginationParams pagination
            )
        {
            var result = _context.Announcements.AsNoTracking();

            if (MasterId.HasValue)
                result = result.Where(x => x.TimeTable.Master.Id == MasterId);

            if (TimeTableId.HasValue)
                result = result.Where(x => x.TimeTableId == TimeTableId);

            var data = await PaginatedList<Announcement>.CreateAsync(result, pagination);
            
            return Ok(data.Result);
        }

        // GET: api/Announcements/5
        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Announcement>> GetAnnouncement(int id)
        {
            var announcement = await _context.Announcements.AsNoTracking()
                .Include(x => x.TimeTable.Master)
                .Include(x => x.TimeTable.TimeTableBells)
                .Include(x => x.TimeTable.Students)
                .FirstOrDefaultAsync();

            if (announcement == null)
            {
                return NotFound();
            }

            return Ok(announcement);
        }

        // POST: api/Announcements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = new string[] { nameof(Admin), nameof(Master) })]
        [HttpPost]
        public async Task<ActionResult<Announcement>> PostAnnouncement([FromBody] AnnouncementRequest model)
        {
            var timeTable = await _context.TimeTables.FindAsync(model.TimeTableId);

            if (timeTable == null)
                return NotFound(msg: "برنامه مورد نطر یافت نشد.");
            
            var newData = new Announcement
            {
                Message = model.Message,
                TimeTable = timeTable,
            };

            _context.Announcements.Add(newData);
            
            await _context.SaveChangesAsync();

            return Ok(newData);
        }

        // DELETE: api/Announcements/5
        [Authorize(Policy = new string[] { nameof(Admin), nameof(Master) })]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }

            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
