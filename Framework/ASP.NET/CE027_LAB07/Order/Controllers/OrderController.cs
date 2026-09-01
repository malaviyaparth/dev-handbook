using Microsoft.AspNetCore.Mvc;
using Order.Models;
using Order.ViewModels;

namespace Order.Controllers
{
    public class OrderController : Controller
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop",      Price = 55000m },
            new Product { Id = 2, Name = "Smartphone",  Price = 25000m },
            new Product { Id = 3, Name = "Headphones",  Price = 2000m  },
            new Product { Id = 4, Name = "Keyboard",    Price = 1200m  },
            new Product { Id = 5, Name = "Monitor",     Price = 9000m  }
        };
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() {

            var model = new OrderViewModel
            {
                AvailableProducts = _products
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AvailableProducts = _products;
                return View(model);
            }

            var selectedProduct = _products.FirstOrDefault(p => p.Id == model.SelectedProductId);

            if (selectedProduct == null)
            {
                ModelState.AddModelError("SelectedProductId", "Selected product does not exist");
                model.AvailableProducts = _products;
                return View(model);
            }

            ViewBag.SelectedProduct = selectedProduct;
            ViewBag.TotalPrice = selectedProduct.Price * model.Quantity;

            return View("OrderSuccess", model);
        }

    }
}
