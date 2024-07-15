using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PianoStoreProject.Data
{
    public class ProductImages
    {
        [Required, Key]
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Products Products { get; set; }
    }
}
