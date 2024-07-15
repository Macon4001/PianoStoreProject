using PianoStoreProject.Models;
using System.Collections.Generic;

namespace PianoStoreProject.Repositories
{
    public interface IProductRepository
    {
        ProductViewModel InitProduct();
        int AddProduct(ProductViewModel product);
        int UpdateProduct(ProductViewModel product);
        ProductViewModel EditProduct(int Id);
        void AddImage(ProductPhotosViewModel _photo);
        List<ProductPhotosViewModel> ProductPhotoListing(int ProductId);
        List<ProductViewModel> GetAllProducts();
        List<ProductViewModel> GetRecomendedProducts();
        bool DeleteProduct(int ProductId);
        IList<ProductViewModel> GetLatestProductListing();
        bool DeleteProductImage(int ImageId);
        IList<ProductViewModel> GetProductListing(ProductsFilterViewModel data);
        ProductViewModel GetItemDetails(int ProductId);
        public List<ProductViewModel> SearchProducts(string query, string category);
    }
}
