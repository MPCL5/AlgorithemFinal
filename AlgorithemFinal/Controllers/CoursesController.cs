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
    public class CoursesController : ControllerExtension
    {
        private readonly AfDbContext _context;

        public CoursesController(AfDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<Course>>> GetCourses(
                [FromQuery] string search,
                [FromQuery] int? unitCount,
                [FromQuery] PaginationParams pagination
            )
        {
            // return await _context.Courses.ToListAsync();
            return Ok();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        /// <summary>
        /// barname zamnie dars haei ke ba id hastano bar migardoune
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        // GET: api/Courses/5/TimeTables
        [HttpGet("{id}/TimeTables")]
        public async Task<ActionResult<PaginatedResult<TimeTable>>> GetCourseTimeTable(
                int id,
                [FromQuery] PaginationParams pagination
            )
        {

            return Ok();
        }

        /// <summary>
        /// ostad haei ke bara in dars hastano barmigardoune
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        // GET: api/Courses/5/Masters
        [HttpGet("{id}/Masters")]
        public async Task<ActionResult<PaginatedResult<Master>>> GetCourseMasters(
                int id,
                [FromQuery] PaginationParams pagination
            )
        {

            return Ok();
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        /// <summary>
        /// baraye entexab kardane dar baraye eraye tavassote ostad. id ostad ro az middlware auth migirin
        /// </summary>
        /// <param name="id">id dars</param>
        /// <returns></returns>
        [HttpPost("{id}/Choose")]
        public async Task<IActionResult> PostChooseCourse(int id)
        {
            return Ok();
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
