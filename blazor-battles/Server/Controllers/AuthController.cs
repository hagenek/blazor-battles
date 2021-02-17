using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blazor_battles.Shared;
using blazor_battles.Shared.Data;

namespace blazor_battles.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegister request)
        {
            var response = await _authRepository.Register(
                new User
                {
                    Username = request.Username,
                    Email = request.Email,
                    Bananas = request.Bananas,
                    DateOfBirth = request.DateOfBirth,
                    IsConfirmed = request.IsConfirmed
                },
                request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
