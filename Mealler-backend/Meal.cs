namespace Mealler_backend;

public class Meal
{
    public int Id { get; set; }

    public float Rating { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
