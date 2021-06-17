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
using AlgorithemFinal.Models.Requests;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search">قسمتی از نام</param>
        /// <param name="unitCount">تعداد واحد</param>
        /// <returns></returns>
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
        /// برنامه زمانی درس هایی که این شناسه را دارند را برمیگرداند.
        /// </summary>
        /// <param name="id">شناسه</param>
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
        /// استاد های درس با شناسه وارد شده را بر می پرداند
        /// </summary>
        /// <param name="id">شناسه</param>
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
        public async Task<IActionResult> PutCourse(int id, CourseRequest course)
        {
            //if (id != course.Id)
            //{
            //    return BadRequest();
            //}

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
        public async Task<ActionResult<Course>> PostCourse(CourseRequest course)
        {
            //_context.Courses.Add(course);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCourse", new { id = course.Id }, course);
            return Ok();
        }

        /// <summary>
        /// استاد درس را برای ارایه انتخاب می کند. لازم که استاد را از طریق میدل ویر شناسایی کنید و از روی توکن
        /// </summary>
        /// <param name="id">شناسه درس</param>
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
