using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Models
{
    public class ProductPhotosViewModel
    {
        public int ProductPhotoId { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Product Image")]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Product Images")]
        [DataType(DataType.Upload)]
        public IList<IFormFile> ProductImages { get; set; }
    }
}
