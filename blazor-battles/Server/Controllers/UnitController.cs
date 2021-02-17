using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blazor_battles.Shared;
using blazor_battles.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace blazor_battles.Server
{
[Route("api/[controller]")]
[ApiController]
public class UnitController : ControllerBase
{
    private readonly DataContext _context;

    public UnitController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task <IActionResult> GetUnits()
    {
        var units = await _context.Units.ToListAsync();
        return Ok(units);
    }

    }
}
