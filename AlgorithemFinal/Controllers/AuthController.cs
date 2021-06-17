using AlgorithemFinal.Models.Requests;
using AlgorithemFinal.Models.Response;
using AlgorithemFinal.Utiles.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerExtension
    {
        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> PostLogin(AuthRequest request)
        {
            return Ok();
        }
    }
}
