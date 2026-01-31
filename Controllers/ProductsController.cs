using BestStoreMVC.Models;
using BestStoreMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestStoreMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var products = context.Products.OrderByDescending(p => p.Id).ToList();
           
            return View(products);
        }
        [HttpPost]
        public IActionResult Create(ProductDto productDto)
        {
            if (productDto == null)
            {
                ModelState.AddModelError("ImageFile", "The Image file is required.");
            }
            if (!ModelState.IsValid)
            {
                return View(productDto);
            }
            return RedirectToAction("Index", "Products");

        }
    }
}
