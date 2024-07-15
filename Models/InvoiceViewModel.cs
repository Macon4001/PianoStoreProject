using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Models
{
    public class InvoiceViewModel
    {
        public string OrderId { get; set; }
        public string OrderDate { get; set; }
        public string Subtotal { get; set; }
        public string ShippingCharges { get; set; }
        public string TotalAmount { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
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
        [Display(Name = "Status")]
        public string StatusId { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
