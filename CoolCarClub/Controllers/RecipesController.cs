using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Data;
using RecipeManager.Models;

namespace RecipeManager.Controllers
{
    [Authorize]
    public class RecipesController : Controller
    {
        private RecipeManagerDbContext context;

        public RecipesController(RecipeManagerDbContext c)
        {
            context = c;
        }

        public IActionResult Index(string searchString, int? categoryId)
        {
            var recipes = context.Recipes
                .Include(r => r.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(r => r.Name.Contains(searchString));
            }

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                recipes = recipes.Where(r => r.CategoryId == categoryId.Value);
            }

            ViewBag.Categories = new SelectList(context.Categories.ToList(), "CategoryId", "Name");

            return View(recipes.ToList());
        }

        public IActionResult Details(int id)
        {
            var recipe = context.Recipes
                .Include(r => r.Category)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefault(r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(context.Categories.ToList(), "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Recipe model)
        {
            if (ModelState.IsValid)
            {
                context.Recipes.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(context.Categories.ToList(), "CategoryId", "Name");
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var recipe = context.Recipes.Find(id);

            if (recipe == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(context.Categories.ToList(), "CategoryId", "Name");
            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Recipe model)
        {
            if (ModelState.IsValid)
            {
                context.Recipes.Update(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(context.Categories.ToList(), "CategoryId", "Name");
            return View(model);
        }

        public IActionResult Calculator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculator(decimal quantity, int originalServings, int newServings)
        {
            ServingCalculator calc = new ServingCalculator();
            ViewBag.Result = calc.AdjustQuantity(quantity, originalServings, newServings);
            ViewBag.Quantity = quantity;
            ViewBag.OriginalServings = originalServings;
            ViewBag.NewServings = newServings;

            return View();
        }
        public IActionResult Delete(int id)
        {
            var recipe = context.Recipes
                .Include(r => r.Category)
                .FirstOrDefault(r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Recipe model)
        {
            var recipe = context.Recipes.Find(model.RecipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            context.Recipes.Remove(recipe);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AddIngredient(int id)
        {
            var recipe = context.Recipes.FirstOrDefault(r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            var model = new RecipeIngredientForm
            {
                RecipeId = recipe.RecipeId,
                RecipeName = recipe.Name
            };

            ViewBag.Ingredients = new SelectList(context.Ingredients.ToList(), "IngredientId", "Name");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddIngredient(RecipeIngredientForm model)
        {
            var recipe = context.Recipes.FirstOrDefault(r => r.RecipeId == model.RecipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                RecipeIngredient recipeIngredient = new RecipeIngredient
                {
                    RecipeId = model.RecipeId,
                    IngredientId = model.IngredientId,
                    Quantity = model.Quantity,
                    Unit = model.Unit
                };

                context.RecipeIngredients.Add(recipeIngredient);
                context.SaveChanges();

                return RedirectToAction("Details", new { id = model.RecipeId });
            }

            ViewBag.Ingredients = new SelectList(context.Ingredients.ToList(), "IngredientId", "Name");
            return View(model);
        }

        public IActionResult DeleteRecipeIngredient(int id, int recipeId)
        {
            var recipeIngredient = context.RecipeIngredients.Find(id);

            if (recipeIngredient == null)
            {
                return NotFound();
            }

            context.RecipeIngredients.Remove(recipeIngredient);
            context.SaveChanges();

            return RedirectToAction("Details", new { id = recipeId });
        }
    }
}