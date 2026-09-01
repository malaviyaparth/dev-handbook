using Order.Models;
using System.ComponentModel.DataAnnotations;

namespace Order.ViewModels
{
    public class OrderViewModel
    {
        public Customer Customer { get; set; }
        public Delivery Delivery { get; set; }

        [Required(ErrorMessage = "Please select a product")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid product")]
        [Display(Name = "Product")]
        public int SelectedProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; }

        public List<Product> AvailableProducts { get; set; } = new List<Product>();
    }
}
