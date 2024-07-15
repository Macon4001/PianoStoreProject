using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PianoStoreProject.Data
{
    public class Orders
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        [Required]
        public decimal ShippingCharges { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public int statusID { get; set; } // 1. Pending 2. Confirmed 3. Shipped 4. Completed 5. Cancelled
        public AppUser User { get; set; }
    }
}
