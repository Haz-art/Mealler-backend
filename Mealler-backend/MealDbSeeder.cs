using Mealler_backend;

public static class MealDbSeeder
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<MealDbContext>();

            // Access the Meals DbSet
            var meals = dbContext.Meals;

            // Check if there are already meals in the database
            if (!meals.Any())
            {
                // Seed the database with initial data
                for (int i = 1; i <= 60; i++)
                {
                    var meal = new Meal
                    {
                        Name = $"Meal {i}",
                        // Set other properties as needed
                    };

                    meals.Add(meal);
                }

                dbContext.SaveChanges();
            }
        }
    }
}
