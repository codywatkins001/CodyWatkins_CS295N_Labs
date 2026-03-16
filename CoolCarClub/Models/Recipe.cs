using System.ComponentModel.DataAnnotations;

namespace RecipeManager.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        [Required]
        public string Instructions { get; set; } = "";

        [Display(Name = "Prep Time (Minutes)")]
        public int PrepTimeMinutes { get; set; }

        [Display(Name = "Cook Time (Minutes)")]
        public int CookTimeMinutes { get; set; }

        public int Servings { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}