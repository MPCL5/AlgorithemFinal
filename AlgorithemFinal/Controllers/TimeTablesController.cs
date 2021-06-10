using System;
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="StudentId">id daneshju</param>
        /// <param name="CourseId">id dars</param>
        /// <param name="MasterId">id ostad</param>
        /// <returns></returns>
        // GET: api/TimeTables
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<TimeTable>>> GetTimeTables(
                [FromQuery] int? StudentId,
                [FromQuery] int? CourseId,
                [FromQuery] int? MasterId,
                [FromQuery] PaginationParams pagination
            )
        {
            // await _context.TimeTables.ToListAsync();
            return Ok();
        }

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

        /// <summary>
        /// ba in API student miad entexab mikone ino. albatte id student az middlware auth miad.
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id}/Choose")]
        public async Task<IActionResult> PostChooseTimeTable()
        {
            return Ok(msg: "afarin bar shoma");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxClassPerBell">tedad class haye mojoud dar daneshkade</param>
        /// <returns></returns>
        [HttpPost("StartProcess")]
        public async Task<IActionResult> PostStartProcess(
                [FromQuery] int maxClassPerBell
            )
        {
            return Ok();
        }

        private bool TimeTableExists(int id)
        {
            return _context.TimeTables.Any(e => e.Id == id);
        }
    }
}
