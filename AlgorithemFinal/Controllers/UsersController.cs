using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlgorithemFinal.Models;
using AlgorithemFinal.Models.Requests;
using AlgorithemFinal.Services;
using AlgorithemFinal.Utiles;
using AlgorithemFinal.Utiles.Extensions;
using AlgorithemFinal.Utiles.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlgorithemFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerExtension
    {
        private readonly AfDbContext _context;

        private readonly IUserService _userService;
        // private readonly HttpContext _httpContext;

        public UsersController(AfDbContext context, IUserService userService)
        {
            // _httpContext = httpContext;
            _userService = userService;
            _context = context;
        }

        // GET: api/Users
        /// <summary>
        /// </summary>
        /// <param name="search">جستجو بر اساس نام کاربر (FirstName + LastName)</param>
        /// <param name="userType">نوع کاربر : ["master", "student"]</param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<User>>> GetUsers(
            [FromQuery] string search,
            [FromQuery] PaginationParams pagination,
            [FromQuery] string userType
        )
        {
            var result = _context.Users.AsNoTracking();

            result = result.Include(x => x.Admin)
                .Include(x => x.Master)
                .Include(x => x.Student);

            if (search != null)
                result = result.Where(user => (user.FirstName + " " + user.LastName).Contains(search));

            userType ??= nameof(Student).ToLower();

            if (userType == nameof(Student).ToLower())
                result = result.Where(user => user.Student != null);
            else if (userType == nameof(Master).ToLower())
                result = result.Where(user => user.Master != null);
            else
                return BadRequest(msg: "نوع کاربر ورودی اشتباه می باشید.");


            var data = await PaginatedList<User>.CreateAsync(result, pagination.Page, pagination.PageSize);
            return Ok(data.Result);
        }

        // GET: api/Users/5
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null) return NotFound();

            return user;
        }

        // GET: api/Users/Profile
        /// <summary>
        ///     دیدن پروفایل شخص لاگین شده بدون شناسه
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("Profile")]
        public ActionResult<User> GetUserProfile()
        {
            // var user = (User)_httpContext.Items["User"];
            var user = (User) HttpContext.Items["User"];

            return Ok(user);
        }

        // POST: api/Users/Profile
        /// <summary>
        ///     ویرایش کردن پروفایل شخص لاگین شده بدون گرفتن شناسه
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("Profile")]
        public async Task<ActionResult<User>> PostUserProfile(
            [FromBody] ProfileRequest model
        )
        {
            // TODO: comment this guy.
            // return PermissionDenied(msg: "temporary disabled.");
           var user = (User) HttpContext.Items["User"];

           user.FirstName = model.FirstName;
           user.LastName = model.LastName;
           
           
           _context.Users.Update(user);

           try
           {
               await _context.SaveChangesAsync();
           }
           catch (DbUpdateConcurrencyException)
           {
               if (!UserExists(user.Id))
                   return NotFound();
               throw;
           }

           return Ok(user);
        }

        // POST: api/Users/Profile/ChangePassword
        /// <summary>
        ///     برای عوض کردن رمز عبور کاربر
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("Profile/ChangePassword")]
        public async Task<ActionResult> PostUserProfileChangePassword(
            [FromBody] ProfilePasswordRequest model
        )
        {
            // TODO: comment this guy.
            // return PermissionDenied(msg: "temporary disabled.");
            var user = (User) HttpContext.Items["User"];

            if (!BCrypt.Net.BCrypt.Verify(model.CurrentPassword, user.Password))
                return BadRequest(msg: "رمزعبور قیلی شما اشتباه است.");

            user.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
            
            _context.Users.Update(user);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                    return NotFound();
                throw;
            }

            return Ok();
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> PutUser(int id, EditUserRequest model)
        {
            // TODO: comment this guy.
            // return PermissionDenied(msg: "temporary disabled.");
            var user = _userService.GetById(id);

            if (user == null) return NotFound();

            if (model.Code != null) user.Code = model.Code;
            if (model.LastName != null) user.LastName = model.LastName;
            if (model.FirstName != null) user.FirstName = model.FirstName;
            if (model.Password != null) user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            _context.Users.Update(user);

            try
            {
                await _context.SaveChangesAsync();

                return Ok(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                    return NotFound();
                throw;
            }
        }

        // DELETE: api/Users/5
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/Users/Add
        /// <summary>
        ///     برای اضافه کردن کاربر به صورت تکی
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpPost("Add")]
        public async Task<ActionResult<User>> PostUser(AddUserRequest model)
        {
            //_context.Users.Add(user);
            //await _context.SaveChangesAsync();
            var validationErrors = new List<object>();

            if (model.FirstName == null)
                validationErrors.Add(new {field = nameof(model.FirstName), message = "نام اجباری می باشد."});
            if (model.LastName == null)
                validationErrors.Add(new {field = nameof(model.LastName), message = "نام خانوادگی اجباری می باشد."});
            if (model.Password == null)
                validationErrors.Add(new {field = nameof(model.Password), message = "رمز عبور اجباری می باشد."});
            if (model.Role == null)
                validationErrors.Add(new {field = nameof(model.Role), message = "نقش اجباری می باشد."});
            if (model.Code == null)
                validationErrors.Add(new {field = nameof(model.Code), message = "شماره کاربر اجباری می باشد."});

            if (validationErrors.Count != 0)
                return BadRequest(data: validationErrors);
            
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Code = model.Code,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password)
            };

            model.Role = model.Role.ToLower();
            
            if (model.Role == nameof(Student).ToLower())
                user.Student = new Student();
            else if (model.Role == nameof(Master).ToLower())
                user.Master = new Master();
            else
                return BadRequest(msg: "نقش انتخابی معتبر نمی باشد.");
            
            _context.Users.Add(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (_context.Users.FirstOrDefault(item => item.Code == user.Code) != null) 
                    return BadRequest(msg: "شماره کاربر تکراری است.");
                throw;
            }
            

            //return CreatedAtAction("GetUser", new { id = user.Id }, user);
            return Ok(user);
        }

        // POST: api/Users/AddList
        /// <summary>
        ///     برای اضافه کردن کاربر به صورت گروهی
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Authorize(Policy = new[] {nameof(Admin)})]
        [HttpPost("AddList")]
        public async Task<ActionResult<User>> PostUserRange(AddUserRequest[] user)
        {
            // i'm too lazy for implementing this guty. but u have to do.
            return PermissionDenied(msg: "temporary disabled.");
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}