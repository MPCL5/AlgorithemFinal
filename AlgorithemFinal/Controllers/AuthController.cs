using System.Threading.Tasks;
using AlgorithemFinal.Models.Requests;
using AlgorithemFinal.Models.Response;
using AlgorithemFinal.Services;
using AlgorithemFinal.Utiles.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithemFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerExtension
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> PostLogin([FromBody] AuthRequest request)
        {
            var result = _userService.Authenticate(request);

            if (result == null)
                return BadRequest(msg: "incorrect username or password");
            
            return Ok(result);
        }
    }
}