using RecipeManager.Models;
using System.Linq;

namespace RecipeManager.Data
{
    public static class SeedData
    {
        public static void Initialize(RecipeManagerDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { CategoryId = 1, Name = "Breakfast" },
                    new Category { CategoryId = 2, Name = "Lunch" },
                    new Category { CategoryId = 3, Name = "Dinner" },
                    new Category { CategoryId = 4, Name = "Dessert" }
                );

                context.SaveChanges();
            }
        }
    }
}