using Microsoft.EntityFrameworkCore;

namespace Mealler_backend;

public class MealDbContext : DbContext
{
    private static readonly string _connectionString = MealDatabaseSettings.DbConnectionString;

    public MealDbContext(DbContextOptions<MealDbContext> options) : base(options)
    {
    }

    public DbSet<Meal> Meals { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
