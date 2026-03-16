using System.ComponentModel.DataAnnotations;

namespace RecipeManager.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public string DefaultUnit { get; set; } = "";

        public List<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}