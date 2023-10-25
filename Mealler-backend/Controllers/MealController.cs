using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Mealler_backend.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MealController : ControllerBase {
    private readonly MealDbContext _context;
    public MealController(MealDbContext context)
    {
        _context = context;
    }

    [HttpPost("meal")]
    public async Task<IActionResult> CreateMeal([FromBody] CreateMealInputModel inputModel)
    {
        if (inputModel == null)
        {
            return BadRequest("Invalid input data");
        }

        var newMeal = new Meal
        {
            Rating = inputModel.Rating,
            Name = inputModel.Name,
            Image = inputModel.Image,
            Description = inputModel.Description,
        };

        _context.Meals.Add(newMeal);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMealsAfterId), new { startId = newMeal.Id, count = 1 }, newMeal);
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
