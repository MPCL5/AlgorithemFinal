using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlgorithemFinal.Models;
using AlgorithemFinal.Utiles;
using AlgorithemFinal.Services;
using AlgorithemFinal.Utiles.Pagination;
using AlgorithemFinal.Utiles.Extensions;
using AlgorithemFinal.Models.Requests;

namespace AlgorithemFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerExtension
    {
        private readonly AfDbContext _context;
        private readonly HttpContext _httpContext;

        public UsersController(AfDbContext context, HttpContext httpContext)
        {
            _httpContext = httpContext;
            _context = context;
        }

        // GET: api/Users
        [Authorize(Policy = new string[] { nameof(Admin) })]
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<User>>> GetUsers(
                [FromQuery] string search,
                [FromQuery] PaginationParams pagination
            )
        {
            var result = _context.Users.AsNoTracking();

            var data = await PaginatedList<User>.CreateAsync(result, pagination.Page, pagination.PageSize);
            return Ok(data.Result);
        }

        // GET: api/Users/5
        [Authorize(Policy = new string[] { nameof(Admin) })]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        [Authorize]
        [HttpGet("Profile")]
        public ActionResult<User> GetUserProfile()
        {
            var user = (User)_httpContext.Items["User"];

            return Ok(user);
        }

        [Authorize]
        [HttpPost("Profile")]
        public ActionResult<User> PostUserProfile(
                [FromBody] ProfileRequest model
            )
        {
            var user = (User)_httpContext.Items["User"];

            return Ok(user);
        }

        [Authorize]
        [HttpPost("Profile/ChangePassword")]
        public IActionResult PostUserProfileChangePassword(
                [FromBody] ProfilePasswordRequest request
            )
        {
            var user = (User)_httpContext.Items["User"];

            return Ok();
        }
        
        //[Authorize]
        //[HttpPost("ChangePassword")]
        //public async Task<IActionResult> PostUserProfileChangePassword(
        //        [FromBody] string CurrentPassword,
        //        [FromBody] string NewPassword
        //    )
        //{
        //    //var user = (User)_httpContext.Items["User"];

        //    return Ok();
        //}

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = new string[] { nameof(Admin) })]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = new string[] { nameof(Admin) })]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [Authorize(Policy = new string[] { nameof(Admin) })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
