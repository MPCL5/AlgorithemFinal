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
using AlgorithemFinal.Utiles;

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
            var result = _context.Courses.AsNoTracking();

            if (search != null)
                result = result.Where(item => item.Title.ToLower().Contains(search.ToLower()));
            if (unitCount.HasValue)
                result = result.Where(item => item.UnitsCount == unitCount);

            var data = await PaginatedList<Course>.CreateAsync(result, pagination);
            
            // return await _context.Courses.ToListAsync();
            return Ok(data.Result);
        }

        // GET: api/Courses/5
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            return course == null ? NotFound() : Ok(course);
        }

        /// <summary>
        /// برنامه زمانی درس هایی که این شناسه را دارند را برمیگرداند.
        /// </summary>
        /// <param name="id">شناسه</param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        // GET: api/Courses/5/TimeTables
        [HttpGet("{id:int}/TimeTables")]
        public async Task<ActionResult<PaginatedResult<TimeTable>>> GetCourseTimeTable(
                int id,
                [FromQuery] PaginationParams pagination
            )
        {
            if (!CourseExists(id))
                return NotFound();

            var result = _context.TimeTables.AsNoTracking()
                .Where(item => item.Master.Id == id);

            var data = await PaginatedList<TimeTable>.CreateAsync(result, pagination);
                
            return Ok(data.Result);
        }

        /// <summary>
        /// استاد های درس با شناسه وارد شده را بر می پرداند
        /// </summary>
        /// <param name="id">شناسه</param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        // GET: api/Courses/5/Masters
        [HttpGet("{id:int}/Masters")]
        [Authorize(Policy = new[] {nameof(Admin)})]
        public async Task<ActionResult<PaginatedResult<Master>>> GetCourseMasters(
                int id,
                [FromQuery] PaginationParams pagination
            )
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
                return NotFound();

            var resultQuery = _context.Entry(course)
                .Collection(x => x.Masters)
                .Query()
                .Include(item => item.User)
                .AsNoTracking();

            var data = await PaginatedList<Master>.CreateAsync(resultQuery, pagination);
            
            return Ok(data.Result);
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutCourse(int id, CourseRequest model)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
                return NotFound();

            if (model.Title != null)
                course.Title = model.Title;
            if (model.UnitsCount.HasValue)
                course.UnitsCount = model.UnitsCount.GetValueOrDefault();

            _context.Courses.Update(course);

            await _context.SaveChangesAsync();

            return Ok(course);
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(CourseRequest model)
        {
            var validationErrors = new List<object>();

            if (model.Title == null)
                validationErrors.Add(new ValidationError
                    {Field = nameof(model.Title), Message = "عنوان اجباری میباشید."});
            if (model.UnitsCount == null)
                validationErrors.Add(new ValidationError
                    {Field = nameof(model.UnitsCount), Message = "تعداد واحد اجباری میباشید."});

            if (validationErrors.Count != 0)
                return BadRequest(validationErrors);

            var newData = new Course { Title = model.Title, UnitsCount = model.UnitsCount.GetValueOrDefault()};
            _context.Courses.Add(newData);

            await _context.SaveChangesAsync();

            return Ok(newData);
        }

        /// <summary>
        /// استاد درس را برای ارایه انتخاب می کند. لازم که استاد را از طریق میدل ویر شناسایی کنید و از روی توکن
        /// </summary>
        /// <param name="id">شناسه درس</param>
        /// <returns></returns>
        [Authorize(Policy = new[] {nameof(Master)})]
        [HttpPost("{id:int}/Choose")]
        public async Task<IActionResult> PostChooseCourse(int id)
        {
            var user = (User) HttpContext.Items["User"];
            var course = await _context.Courses
                .Include(item => item.Masters)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (course == null)
                return NotFound();

            if (course.Masters.Any(item => item.Id == user.Master.Id))
                course.Masters.Remove(user.Master);
            else
                course.Masters.Add(user.Master);

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            
            return Ok();
        }

        // DELETE: api/Courses/5
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpDelete("{id:int}")]
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
