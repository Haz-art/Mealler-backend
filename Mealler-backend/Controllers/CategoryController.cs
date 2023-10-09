using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Mealler_backend.Controllers;

[ApiController]
[Route("api/categories")]

public class CategoryController : ControllerBase {
    private readonly MealDbContext _context;
    public CategoryController(MealDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        var categories = await _context.Categories.ToListAsync();
        return Ok(categories);
    }
}
