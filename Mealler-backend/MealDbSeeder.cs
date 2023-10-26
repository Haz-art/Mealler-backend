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
            var random = new Random();
            var categories = _context.Categories.ToList();

            var meals = new List<Meal>
            {
                new Meal
                {
                    Name = "Spaghetti Carbonara",
                    Image = "https://www.allrecipes.com/thmb/Vg2cRidr2zcYhWGvPD8M18xM_WY=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/11973-spaghetti-carbonara-ii-DDMFS-4x3-6edea51e421e4457ac0c3269f3be5157.jpg",
                    Description = "Spaghetti Carbonara is an Italian classic. Cook spaghetti, sauté pancetta, and mix with a creamy egg and cheese sauce. Season with black pepper for a flavorful, comforting dish.",
                    Rating = random.Next(1, 6),
                    MealCategories = new List<MealCategory>
                    {
                        new MealCategory { Category = categories[4] }, // Italian
                        new MealCategory { Category = categories[1] }, // Burgers
                    }
                },
                new Meal
                {
                    Name = "Sushi Roll",
                    Image = "https://ichisushi.com/wp-content/uploads/2022/05/Best-Hawaiian-Roll-Sushi-Recipes.jpg",
                    Description = "Sushi Rolls are a staple of Japanese cuisine. Roll sushi rice, fresh fish, and vegetables in seaweed, then slice into bite-sized pieces. Serve with soy sauce and wasabi.",
                    Rating = random.Next(1, 6),
                    MealCategories = new List<MealCategory>
                    {
                        new MealCategory { Category = categories[8] }, // Japanese
                        new MealCategory { Category = categories[2] }, // Sushi
                    }
                },
                new Meal
                {
                    Name = "Chicken Tikka Masala",
                    Image = "https://www.allrecipes.com/thmb/1ul-jdOz8H4b6BDrRcYOuNmJgt4=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/239867chef-johns-chicken-tikka-masala-ddmfs-3X4-0572-e02a25f8c7b745459a9106e9eb13de10.jpg",
                    Description = "Chicken Tikka Masala is a beloved Indian dish. Marinate chicken in yogurt and spices, grill, and simmer in a creamy tomato sauce for a rich, flavorful meal.",
                    Rating = random.Next(1, 6),
                    MealCategories = new List<MealCategory>
                    {
                        new MealCategory { Category = categories[6] }, // Indian
                    }
                },
                new Meal
                {
                    Name = "Caesar Salad",
                    Image = "https://food-images.files.bbci.co.uk/food/recipes/easy_caesar_salad_64317_16x9.jpg",
                    Description = "Caesar Salad is a classic salad. Toss fresh romaine lettuce with Caesar dressing, croutons, and Parmesan cheese. It's a simple and refreshing choice.",
                    Rating = random.Next(1, 6),
                    MealCategories = new List<MealCategory>
                    {
                        new MealCategory { Category = categories[4] }, // Italian
                    }
                },
                new Meal
                {
                    Name = "Hamburger",
                    Image = "https://www.tastingtable.com/img/gallery/heres-how-hamburgers-got-their-name/l-intro-1653066580.jpg",
                    Description = "Hamburgers are a quintessential American fast food. Grill or fry beef patties, place them in buns, and add your favorite toppings like lettuce, tomato, and cheese.",
                    Rating = random.Next(1, 6),
                    MealCategories = new List<MealCategory>
                    {
                        new MealCategory { Category = categories[1] }, // Burgers
                    }
                },
                new Meal
                {
                    Name = "Sushi Nigiri",
                    Image = "https://houseofasia.pl/wp-content/uploads/2020/12/nigiri_sishi_losos_krewetka_wegorz_tunczyk_house_of_asia.jpg",
                    Description = "Sushi Nigiri is a Japanese delicacy. Top small beds of seasoned rice with slices of fresh fish or seafood. Serve with soy sauce and pickled ginger.",
                    Rating = random.Next(1, 6),
                    MealCategories = new List<MealCategory>
                    {
                        new MealCategory { Category = categories[8] }, // Japanese
                        new MealCategory { Category = categories[2] }, // Sushi
                    }
                },
                new Meal
                {
                    Name = "Margarita Pizza",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/c/c8/Pizza_Margherita_stu_spivack.jpg",
                    Description = "Margarita Pizza is an Italian classic. Spread tomato sauce, fresh mozzarella, basil leaves, and olive oil on pizza dough, then bake for a simple yet delicious pizza.",
                    Rating = random.Next(1, 6),
                    MealCategories = new List<MealCategory>
                    {
                        new MealCategory { Category = categories[4] }, // Italian
                    }
                },
                new Meal
                {
                    Name = "Pad Thai",
                    Image = "https://staticsmaker.iplsc.com/smaker_production_2023_03_03/9d4105132f31fbff06ab61d5f11dbd62-recipe_main.jpg",
                    Description = "Pad Thai is a popular Thai stir-fried noodle dish. Sauté rice noodles with shrimp, tofu, eggs, and a flavorful sauce, garnished with peanuts and lime.",
                    Rating = random.Next(1, 6),
                    MealCategories = new List<MealCategory>
                    {
                        new MealCategory { Category = categories[7] }, // Chinese
                    }
                },
                new Meal
                {
                    Name = "Grilled Salmon",
                    Image = "https://hips.hearstapps.com/hmg-prod/images/how-to-grill-salmon-recipe1-1655870645.jpg",
                    Description = "Grilled Salmon is a healthy and delicious choice. Season salmon fillets, grill until flaky, and serve with your favorite sides for a nutritious meal.",
                    Rating = random.Next(1, 6),
                    MealCategories = new List<MealCategory>
                    {
                        new MealCategory { Category = categories[6] }, // Indian
                    }
                }
            };
            _context.Meals.AddRange(meals);
            _context.SaveChanges();
        }
    }
}
