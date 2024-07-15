using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Models
{
    public class CategoriesViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        [Display(Name = "Category Image")]
        [DataType(DataType.Upload)]
        public IFormFile CategoryImage { get; set; }
        [Display(Name = "Category Image")]
        public string CategoryImageUrl { get; set; }
    }
}
