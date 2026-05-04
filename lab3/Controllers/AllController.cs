using lab3.Data.Context;
using lab3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace lab3.Controllers
{
    public class AllController : Controller
    {
        private readonly AppDbContext db;

        public AllController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new AllVM
            {
                Categories = db.Categories
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList()
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var products = db.Products
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Title
                })
                .ToList();
            return Json(products);
        }

        [HttpGet]
        public IActionResult GetProductDetails(int productId)
        {
            var product = db.Products.Include(p => p.Category)
                .Where(p => p.Id == productId)
                .Select(p => new ProductReadVM
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = p.Price,
                    Count = p.Count,
                    CategoryName = p.Category!.Name
                })
                .FirstOrDefault();

            return PartialView("_ProductTablePartial", product);
        }
    }
}
