namespace RecipeManager.Models
{
    public class RecipeIngredientForm
    {
        public int RecipeId { get; set; }

        public string RecipeName { get; set; } = "";

        public int IngredientId { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; } = "";
    }
}