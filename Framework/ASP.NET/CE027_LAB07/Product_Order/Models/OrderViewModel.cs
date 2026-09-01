using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Product_Order.Models
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Customer name must be between 3 and 100 characters")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? EmailAddress { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Product selection is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid product")]
        public int SelectedProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Delivery address is required")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Address must be between 10 and 200 characters")]
        public string? DeliveryAddress { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "City must be between 2 and 50 characters")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Please enter a valid postal code")]
        public string? PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Country must be between 2 and 50 characters")]
        public string? Country { get; set; }

        // Properties for displaying available products in the view
        // These are not form inputs, only for display purposes
        [BindNever]
        public List<Product> AvailableProducts { get; set; } = new();

        [BindNever]
        public string? SelectedProductName { get; set; }

        [BindNever]
        public decimal SelectedProductPrice { get; set; }

        [BindNever]
        public decimal TotalPrice { get; set; }

        [BindNever]
        public DateTime OrderDate { get; set; } = DateTime.MinValue;
    }

    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
