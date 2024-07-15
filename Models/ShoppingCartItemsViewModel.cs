using System;

namespace PianoStoreProject.Models
{
    public class ShoppingCartItemsViewModel
    {
        public int Id { get; set; }
        public string CartId { get; set; }
        public string CreatedDate { get; set; }
        public int ProductId { get; set; }
		public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
		public int Quantity { get; set; }
        public string SubTotal { get; set; }
    }
}
