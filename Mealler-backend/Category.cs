﻿namespace Mealler_backend;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<MealCategory> MealCategories { get; set; }
}
