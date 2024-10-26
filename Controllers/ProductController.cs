using Markata.Data;
using Microsoft.AspNetCore.Mvc;
using Markata.Models;

namespace Markata.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationContext _context;

        public ProductController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProductForCreation();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductForCreation model)
        {
            var product = new Product
            {
                Name = model.Name,
                Price=model.Price,
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);

            var model = new ProductForModification
            {
                Id = id,
                Name = product.Name,
                Price = product.Price
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductForModification model)
        {
            var product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price
            };

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}

