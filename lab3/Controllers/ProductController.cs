using lab3.Models;
using lab3.Repositories.CategoryRepository;
using lab3.Repositories.ProductRepository;
using lab3.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace lab3.Controllers
{
    [Authorize]   
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;

        public ProductController(IProductRepository productRepo, ICategoryRepository categoryRepo)
        {
            _productRepo  = productRepo;
            _categoryRepo = categoryRepo;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index([FromQuery] int? categoryId)
        {
            var products = _productRepo.GetAll(categoryId)
                .Select(p => new ProductReadVM
                {
                    Id           = p.Id,
                    Title        = p.Title,
                    Description  = p.Description,
                    Price        = p.Price,
                    Count        = p.Count,
                    CategoryName = p.Category!.Name,
                    ExpiryDate   = p.ExpiryDate,
                }).ToList();

            var recentProductsJson = Request.Cookies["RecentProducts"];
            List<ProductReadVM> recentProductsVM = new();

            if (!string.IsNullOrEmpty(recentProductsJson))
            {
                var recentIds = JsonSerializer.Deserialize<List<int>>(recentProductsJson)!;

                recentProductsVM = _productRepo.GetAll()
                    .Where(p => recentIds.Contains(p.Id))
                    .Select(p => new ProductReadVM
                    {
                        Id    = p.Id,
                        Title = p.Title,
                        Price = p.Price,
                        Count = p.Count
                    }).ToList();

                recentProductsVM = recentIds
                    .Join(recentProductsVM,
                          id => id,
                          p  => p.Id,
                          (id, p) => p)
                    .ToList();
            }

            ViewBag.RecentProducts = recentProductsVM;
            return View(products);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details([FromRoute] int id)
        {
            var product = _productRepo.GetById(id);
            if (product == null)
                return RedirectToAction("Error");

            var vm = new ProductReadVM
            {
                Id           = product.Id,
                Title        = product.Title,
                Description  = product.Description,
                Price        = product.Price,
                Count        = product.Count,
                CategoryName = product.Category!.Name,
                ImageName    = product.ImageName,
                ExpiryDate   = product.ExpiryDate,
            };

            var recentProductsJson = Request.Cookies["RecentProducts"];
            List<int> recentIds = new();

            if (!string.IsNullOrEmpty(recentProductsJson))
                recentIds = JsonSerializer.Deserialize<List<int>>(recentProductsJson)!;

            recentIds.Remove(product.Id);
            recentIds.Insert(0, product.Id);
            recentIds = recentIds.Take(5).ToList();

            Response.Cookies.Append("RecentProducts",
                JsonSerializer.Serialize(recentIds),
                new CookieOptions
                {
                    Expires    = DateTimeOffset.UtcNow.AddDays(7),
                    HttpOnly   = true,
                    IsEssential = true
                });

            return View(vm);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var vm = new ProductCreateVM { Categories = GetCategories() };
            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCreateVM vm)
        {
            int counter = HttpContext.Session.GetInt32("Counter") ?? 0;
            counter++;
            HttpContext.Session.SetInt32("Counter", counter);
            TempData["createdProductNO"] = $"You created {counter} Products";

            if (!ModelState.IsValid)
            {
                vm.Categories = GetCategories();
                return View(vm);
            }

            string? imagePath = null;
            if (vm.Image != null)
            {
                var ext = Path.GetExtension(vm.Image.FileName).ToLower();
                if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(ext))
                {
                    ModelState.AddModelError("Image", "Only .jpg, .jpeg, .png allowed");
                    vm.Categories = GetCategories();
                    return View(vm);
                }
                if (vm.Image.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("Image", "Max file size is 2MB");
                    vm.Categories = GetCategories();
                    return View(vm);
                }

                var fileName = Guid.NewGuid() + ext;
                var path     = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                    vm.Image.CopyTo(stream);

                imagePath = fileName;
            }

            var product = new Product
            {
                Title       = vm.Title,
                Description = vm.Description,
                Price       = vm.Price,
                Count       = vm.Count,
                CategoryId  = vm.CategoryId,
                ExpiryDate  = vm.ExpiryDate,
                ImageName   = imagePath
            };

            _productRepo.Insert(product);
            _productRepo.Save();
            TempData["createdProduct"] = $"Product {vm.Title} created successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var product = _productRepo.GetById(id);
            if (product == null)
                return RedirectToAction("Error");

            var vm = new ProductEditVM
            {
                Id                = product.Id,
                Title             = product.Title,
                Description       = product.Description,
                Price             = product.Price,
                Count             = product.Count,
                CategoryId        = product.CategoryId,
                CategoryName      = product.Category!.Name,
                ExistingImageName = product.ImageName,
                ExpiryDate        = product.ExpiryDate,
                Categories        = GetCategories()
            };

            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductEditVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = GetCategories();
                return View(vm);
            }

            var product = _productRepo.GetById(vm.Id);
            if (product == null)
                return RedirectToAction("Error");

            product.Title       = vm.Title;
            product.Description = vm.Description;
            product.Price       = vm.Price;
            product.Count       = vm.Count;
            product.CategoryId  = vm.CategoryId;
            product.ExpiryDate  = vm.ExpiryDate;

            if (vm.Image != null)
            {
                if (!string.IsNullOrEmpty(product.ImageName))
                {
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", product.ImageName);
                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                var ext      = Path.GetExtension(vm.Image.FileName);
                var fileName = Guid.NewGuid() + ext;
                var path     = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                    vm.Image.CopyTo(stream);

                product.ImageName = fileName;
            }

            _productRepo.Save();
            TempData["EditedProduct"] = $"Product {vm.Title} edited successfully";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var product = _productRepo.GetById(id);
            if (product == null)
                return RedirectToAction("Error");

            if (!string.IsNullOrEmpty(product.ImageName))
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", product.ImageName);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
            }

            _productRepo.Delete(product);
            _productRepo.Save();
            TempData["DeletedProduct"] = $"Product {product.Title} deleted successfully";
            return RedirectToAction("Index");
        }


        private List<SelectListItem> GetCategories() =>
            _categoryRepo.GetAll()
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();

        public IActionResult Error() => View();

        [AcceptVerbs("GET", "POST")]
        public IActionResult IsTitleAvailable(string title, int id)
        {
            if (_productRepo.IsTitleExists(title, id))
                return Json($"Title '{title}' already exists");

            return Json(true);
        }
    }
}
