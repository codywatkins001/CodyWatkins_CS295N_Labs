namespace RecipeManager.Models
{
    public class ServingCalculator
    {
        public decimal AdjustQuantity(decimal quantity, int originalServings, int newServings)
        {
            if (originalServings <= 0 || newServings <= 0)
            {
                return 0;
            }

            return quantity * newServings / originalServings;
        }
    }
}