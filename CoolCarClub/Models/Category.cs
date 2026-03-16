using System.ComponentModel.DataAnnotations;
using RecipeManager.Data;

namespace RecipeManager.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}