using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PianoStoreProject.Data
{
    public class OrderItems
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        [ForeignKey("Orders")]
        [Required]
        public int OrderId { get; set; }
        public Orders Orders { get; set; }
        public Products Products { get; set; }

    }
}
