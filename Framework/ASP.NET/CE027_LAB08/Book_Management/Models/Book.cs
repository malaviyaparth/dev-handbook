using System.ComponentModel.DataAnnotations;

namespace Book_Management.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        [Required(ErrorMessage = "Title is required.")]
        public required string Title { get; set; }

        [StringLength(100, ErrorMessage = "Author cannot exceed 100 characters.")]
        [Required(ErrorMessage = "Author is required.")]
        public  required string Author { get; set; }

        [StringLength(100, ErrorMessage = "Category cannot exceed 100 characters.")]
        [Required(ErrorMessage = "Category is required.")]
        public required string Category { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Published year is required.")]
        [Range(1000, 2100, ErrorMessage = "Invalid published year.")]
        public int PublishedYear { get; set; }
    }
}
