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

        //n-n relation (Meal - Category)
        modelBuilder.Entity<MealCategory>()
            .HasKey(mc => new { mc.MealId, mc.CategoryId });

        modelBuilder.Entity<MealCategory>()
            .HasOne(mc => mc.Meal)
            .WithMany(m => m.MealCategories)
            .HasForeignKey(mc => mc.MealId);

        modelBuilder.Entity<MealCategory>()
            .HasOne(mc => mc.Category)
            .WithMany(c => c.MealCategories)
            .HasForeignKey(mc => mc.CategoryId);
    }

}
