namespace Mealler_backend;

public class MealCategory
{
    public int MealId { get; set; }
    public Meal Meal { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
