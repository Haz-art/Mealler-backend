using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Mealler_backend.Controllers;

[Route("api/[controller]")]
[ApiController]

public class MealController : ControllerBase {
    private readonly MealDbContext _context;
    public MealController(MealDbContext context)
    {
        _context = context;
    }

    [HttpGet("meal")]
    public async Task<IActionResult> GetMealsAfterId([FromQuery] int startId, [FromQuery] int count)
    {
        // Query the database to retrieve meals based on the provided ID and count
        var meals = await _context.Meals
            .Where(m => m.Id >= startId)
            .Take(count)
            .ToListAsync();

        if (meals == null || meals.Count == 0)
        {
            return NotFound();
        }

        return Ok(meals);
    }
}
