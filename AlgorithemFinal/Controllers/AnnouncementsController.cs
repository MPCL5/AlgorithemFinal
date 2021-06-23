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
            
            //return await _context.Announcements.ToListAsync();
            return Ok();
        }

        // GET: api/Announcements/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Announcement>> GetAnnouncement(int id)
        {
            var announcement = await _context.Announcements.FindAsync(id);

            if (announcement == null)
            {
                return NotFound();
            }

            return announcement;
        }

        // PUT: api/Announcements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize(Policy = new string[] { nameof(Admin), nameof(Master) })]
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAnnouncement(int id, [FromBody] AnnouncementRequest announcement)
        //{
        //    //if (id != announcement.Id)
        //    //{
        //    //    return BadRequest();
        //    //}

        //    _context.Entry(announcement).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AnnouncementExists(id))
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

        // POST: api/Announcements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = new string[] { nameof(Admin), nameof(Master) })]
        [HttpPost]
        public async Task<ActionResult<Announcement>> PostAnnouncement([FromBody] AnnouncementRequest announcement)
        {
            //_context.Announcements.Add(announcement);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetAnnouncement", new { id = announcement.Id }, announcement);
            return Ok();
        }

        // DELETE: api/Announcements/5
        [Authorize(Policy = new string[] { nameof(Admin), nameof(Master) })]
        [HttpDelete("{id}")]
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

        private bool AnnouncementExists(int id)
        {
            return _context.Announcements.Any(e => e.Id == id);
        }
    }
}
