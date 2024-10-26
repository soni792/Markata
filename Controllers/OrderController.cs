using Markata.Data;
using Markata.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Markata.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationContext _context;

        public OrderController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.Include(o => o.Product).ToListAsync();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new OrderForCreation();
            model.Products = _context.Products.ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderForCreation model)
        {
            var order = new Order
            {              
                Name = model.Name,
                Quantity = model.Quantity,
                ProductId = model.ProductId,
                Cost = model.Cost
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}