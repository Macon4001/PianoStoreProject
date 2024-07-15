using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Models
{
    public class OrderViewModel
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        [Display(Name = "Sub Total")]
        public string SubTotal { get; set; }
        [Display(Name = "Shipping Charges")]
        public string ShippingCharges { get; set; }
        [Display(Name = "Total Amount")]
        public string TotalAmount { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
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
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        public string Phone { get; set; }

        //Binding
        public string Datetime { get; set; }
        public string status { get; set; }

        public List<OrderProductViewModel> OrderItems { get; set; }
    }
}
