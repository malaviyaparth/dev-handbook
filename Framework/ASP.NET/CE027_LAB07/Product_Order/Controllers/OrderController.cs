using Microsoft.AspNetCore.Mvc;
using Product_Order.Models;
using System.Text.Json;

namespace Product_Order.Controllers
{
    public class OrderController : Controller
    {
        // Static order history storage (in-memory, thread-safe)
        private static List<OrderViewModel> _orderHistory = new();
        private static readonly object _lockObject = new object();

        // Sample products data (in-memory)
        private static List<Product> GetAvailableProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Pro Keyboard", Price = 79.99m, Description = "Wireless mechanical keyboard" },
                new Product { Id = 2, Name = "HD Monitor", Price = 199.99m, Description = "27-inch 4K display" },
                new Product { Id = 3, Name = "USB-C Hub", Price = 49.99m, Description = "7-in-1 multiport adapter" },
                new Product { Id = 4, Name = "Webcam 1080p", Price = 89.99m, Description = "Full HD web camera" },
                new Product { Id = 5, Name = "Wireless Mouse", Price = 34.99m, Description = "Ergonomic design" }
            };
        }

        // GET: Order/Index - Display all products
        public IActionResult Index()
        {
            var products = GetAvailableProducts();
            return View(products);
        }

        // GET: Order/Create - Display the order form with optional pre-selected product
        public IActionResult Create(int? productId)
        {
            var model = new OrderViewModel
            {
                AvailableProducts = GetAvailableProducts()
            };

            // If a product is pre-selected
            if (productId.HasValue)
            {
                var selectedProduct = model.AvailableProducts.FirstOrDefault(p => p.Id == productId);
                if (selectedProduct != null)
                {
                    model.SelectedProductId = selectedProduct.Id;
                    model.SelectedProductName = selectedProduct.Name;
                    model.SelectedProductPrice = selectedProduct.Price;
                    model.Quantity = 1; // Default quantity
                }
            }

            return View(model);
        }

        // POST: Order/Create - Process the submitted form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderViewModel model)
        {
            // Populate available products for view in case of validation failure
            model.AvailableProducts = GetAvailableProducts();

            if (ModelState.IsValid)
            {
                // Get the selected product details
                var selectedProduct = model.AvailableProducts.FirstOrDefault(p => p.Id == model.SelectedProductId);

                if (selectedProduct != null)
                {
                    // Set product details and calculate total price
                    model.SelectedProductName = selectedProduct.Name;
                    model.SelectedProductPrice = selectedProduct.Price;
                    model.TotalPrice = selectedProduct.Price * model.Quantity;
                    model.OrderDate = DateTime.Now;

                    // Store order in Session and redirect to confirmation page
                    var jsonOrder = JsonSerializer.Serialize(model);
                    HttpContext.Session.SetString("Order", jsonOrder);
                    return RedirectToAction(nameof(Confirmation));
                }
                else
                {
                    ModelState.AddModelError("SelectedProductId", "Selected product not found");
                }
            }

            return View(model);
        }

        // GET: Order/Confirmation - Display order confirmation
        public IActionResult Confirmation()
        {
            // Retrieve order from Session
            var jsonOrder = HttpContext.Session.GetString("Order");
            if (string.IsNullOrEmpty(jsonOrder))
            {
                return RedirectToAction(nameof(Create));
            }

            var model = JsonSerializer.Deserialize<OrderViewModel>(jsonOrder);
            if (model == null)
            {
                return RedirectToAction(nameof(Create));
            }

            // Calculate total price if not already set
            if (model.TotalPrice == 0 && model.SelectedProductPrice > 0)
            {
                model.TotalPrice = model.SelectedProductPrice * model.Quantity;
            }

            return View(model);
        }

        // POST: Order/Complete - Save order to history and clear session
        [HttpPost]
        public IActionResult Complete()
        {
            // Retrieve order from Session
            var jsonOrder = HttpContext.Session.GetString("Order");
            if (string.IsNullOrEmpty(jsonOrder))
            {
                return RedirectToAction(nameof(Index));
            }

            var model = JsonSerializer.Deserialize<OrderViewModel>(jsonOrder);
            if (model != null)
            {
                // Set order date
                if (model.OrderDate == DateTime.MinValue)
                {
                    model.OrderDate = DateTime.Now;
                }

                // Add to order history (thread-safe)
                lock (_lockObject)
                {
                    _orderHistory.Add(model);
                }

                // Clear session
                HttpContext.Session.Remove("Order");

                // Redirect to history
                return RedirectToAction(nameof(History));
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Order/History - Display all orders
        public IActionResult History()
        {
            List<OrderViewModel> orders;
            lock (_lockObject)
            {
                orders = new List<OrderViewModel>(_orderHistory);
            }

            // Sort by date descending (newest first)
            orders = orders.OrderByDescending(o => o.OrderDate).ToList();
            return View(orders);
        }
    }
}
