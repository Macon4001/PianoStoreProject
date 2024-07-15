using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PianoStoreProject.Data
{
    public class Products
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [Required]
        public bool Recomended { get; set; }
        public string DefaultImageUrl { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductImages> ProductImages { get; set; }
        public ICollection<ShoppingCartItems> ShoppingCartItems { get; set; }
    }
}
