using System.ComponentModel.DataAnnotations;

namespace Order.Models
{
    public class Delivery
    {
        [Required(ErrorMessage = "Delivery address is required")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        [Display(Name = "Delivery Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Delivery date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Delivery Date")]
        public DateTime DeliveryDate { get; set; } = DateTime.Today.AddDays(1);
    }
}
