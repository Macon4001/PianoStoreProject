using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Models
{
    public class OrderProductViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Price")]
        public string Price { get; set; }
        public string ProductImage { get; set; }
        public string SubTotal { get; set; }

    }
}
