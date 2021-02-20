using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorBattles.Shared;
using BlazorBattles.Shared.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BlazorBattles.Server.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        [Authorize]
    public class UserController : Controller
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        private async Task<User> GetUser () => await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

        [HttpGet("GetBananas")]
        public async Task<IActionResult> GetBananas()
        {
            var user = await GetUser();
            return Ok(user.Bananas);
        }

        [HttpPut("AddBBananas")]
        public async Task<IActionResult> AddBananas([FromBody] int bananas)
        {
            var user = await GetUser();
            user.Bananas += bananas;

            await _context.SaveChangesAsync();
            return Ok(user.Bananas);
        }
    }
}
