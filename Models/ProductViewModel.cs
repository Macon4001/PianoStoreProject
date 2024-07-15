using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Categories = new List<CategoriesViewModel>();
        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Recomended Product")]
        public bool Recomended { get; set; }
        [Required]
        [Display(Name = "Price")]
        public string Price { get; set; }
        public List<CategoriesViewModel> Categories { get; set; }
    
        // Binded Properties
        [Display(Name = "Default Image")]
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public int PageNumber { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
        public List<string> Images { get; set; }
    }
}
