using lab3.Models;
using lab3.Repositories.CategoryRepository;
using lab3.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreD03.Controllers
{
    [Authorize]   
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }


        [HttpGet]
        [AllowAnonymous] 
        public IActionResult Index()
        {
            var categories = _categoryRepo.GetAll()
                .Select(c => new CategoryReadVM
                {
                    Id            = c.Id,
                    Name          = c.Name,
                    ProductsCount = c.Products!.Count
                }).ToList();

            return View(categories);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var category = _categoryRepo.GetById(id);
            if (category == null)
                return RedirectToAction("Error");

            var vm = new CategoryReadVM
            {
                Id            = category.Id,
                Name          = category.Name,
                ProductsCount = category.Products!.Count
            };

            return View(vm);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryCreateVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var category = new Category { Name = vm.Name };
            _categoryRepo.Insert(category);
            _categoryRepo.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var category = _categoryRepo.GetById(id);
            if (category == null)
                return RedirectToAction("Error");

            var vm = new CategoryEditVM
            {
                Id   = category.Id,
                Name = category.Name
            };

            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryEditVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var category = _categoryRepo.GetById(vm.Id);
            if (category == null)
                return RedirectToAction("Error");

            category.Name = vm.Name;
            _categoryRepo.Update(category);
            _categoryRepo.Save();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var category = _categoryRepo.GetById(id);
            if (category == null)
                return RedirectToAction("Error");

            _categoryRepo.Delete(category);
            _categoryRepo.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _categoryRepo.GetById(id);
            if (category == null)
                return RedirectToAction("Error");

            if (category.Products != null && category.Products.Any())
                return RedirectToAction("Error");

            _categoryRepo.Delete(category);
            _categoryRepo.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Error() => View();
    }
}
