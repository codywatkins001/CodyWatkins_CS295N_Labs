using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Data;
using RecipeManager.Models;

namespace RecipeManager.Controllers
{
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
    }
}