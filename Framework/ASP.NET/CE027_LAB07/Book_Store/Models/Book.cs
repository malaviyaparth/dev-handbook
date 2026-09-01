using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book name is required")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Book name must be between 3 and 200 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 1000 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100000, ErrorMessage = "Price must be between ₹0.01 and ₹100000")]
        public decimal Price { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public double Rating { get; set; }

        [Required(ErrorMessage = "Author name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Author name must be between 3 and 100 characters")]
        public string Author { get; set; } = string.Empty;

        [StringLength(100)]
        public string Publisher { get; set; } = string.Empty;

        [Range(1900, 2100, ErrorMessage = "Please enter a valid year")]
        public int? PublishedYear { get; set; }
    }
}
