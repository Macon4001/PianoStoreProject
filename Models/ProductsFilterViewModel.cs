namespace PianoStoreProject.Models
{
    public class ProductsFilterViewModel
    {
        public int CategoryId { get; set; }
        // Pagination
        public int PageNumber { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
    }
}
