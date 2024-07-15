using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Data
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Products>();
        }
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        [Required]
        public string CategoryImageUrl { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
