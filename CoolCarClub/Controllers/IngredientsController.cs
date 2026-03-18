using Microsoft.AspNetCore.Mvc;
using RecipeManager.Data;
using RecipeManager.Models;

namespace RecipeManager.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly RecipeManagerDbContext context;

        public IngredientsController(RecipeManagerDbContext c)
        {
            context = c;
        }

        public IActionResult Index()
        {
            var ingredients = context.Ingredients.ToList();
            return View(ingredients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ingredient model)
        {
            if (ModelState.IsValid)
            {
                context.Ingredients.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var ingredient = context.Ingredients.Find(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ingredient model)
        {
            if (ModelState.IsValid)
            {
                context.Ingredients.Update(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var ingredient = context.Ingredients.Find(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Ingredient model)
        {
            var ingredient = context.Ingredients.Find(model.IngredientId);

            if (ingredient == null)
            {
                return NotFound();
            }

            context.Ingredients.Remove(ingredient);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}