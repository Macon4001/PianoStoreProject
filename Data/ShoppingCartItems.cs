using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PianoStoreProject.Data
{
    public class ShoppingCartItems
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string CartOrUserId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Products Products { get; set; }
    }
}
