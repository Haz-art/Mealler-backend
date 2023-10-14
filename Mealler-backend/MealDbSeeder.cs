using Mealler_backend;

public class MealDbSeeder
{
    private readonly MealDbContext _context;

    public MealDbSeeder(MealDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        SeedCategories();
        SeedMeals();
    }

    private void SeedCategories()
    {
        if (!_context.Categories.Any())
        {
            var categories = new List<Category>
            {
                new Category { Name = "Pizza" },
                new Category { Name = "Burgers" },
                new Category { Name = "Sushi" },
                new Category { Name = "Mexican" },
                new Category { Name = "Italian" },
                new Category { Name = "Chinese" },
                new Category { Name = "Indian" },
                new Category { Name = "Mediterranean" },
                new Category { Name = "Japanese" },
            };

            _context.Categories.AddRange(categories);
            _context.SaveChanges();
        }
    }

    private void SeedMeals()
    {
        if (!_context.Meals.Any())
        {
            // Add at least 90 meals
            var random = new Random();
            var categories = _context.Categories.ToList();

            var meals = new List<Meal>();
            for (int i = 1; i <= 90; i++)
            {
                var meal = new Meal
                {
                    Name = $"Meal {i}",
                    Rating = random.Next(1, 6),
                    Image = "meal_image_url", // Set your image URL
                    Description = "Meal description",
                };

                // Assign random categories to meals
                var selectedCategories = categories
                    .OrderBy(c => Guid.NewGuid()) // Shuffle the list of categories
                    .Take(1)//.Take(random.Next(1, 4)) // Randomly select 1-3 categories
                    .ToList();

                meal.MealCategories = selectedCategories
                    .Select(c => new MealCategory { CategoryId = c.Id })
                    .ToList();

                meals.Add(meal);
            }

            _context.Meals.AddRange(meals);
            _context.SaveChanges();
        }
    }
}
