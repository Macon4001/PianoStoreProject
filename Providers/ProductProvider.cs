using Microsoft.EntityFrameworkCore;
using PianoStoreProject.Data;
using PianoStoreProject.Models;
using PianoStoreProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PianoStoreProject.Providers
{
    public class ProductProvider : IProductRepository
    {
        private IImageRepository _image { get; set; }
        private PSPDBContext _context { get; }
        private ICategoryRepository _category { get; set; }
        public ProductProvider(PSPDBContext context, IImageRepository image, ICategoryRepository category)
        {
            _category = category;
            _image = image;
            _context = context;
        }
        public ProductViewModel InitProduct()
        {
            ProductViewModel _product = new ProductViewModel()
            {
                Categories = _category.GetAllCategories(),
            };
            return _product;
        }
        public int AddProduct(ProductViewModel product)
        {
            Products _product = new Products()
            {
                CategoryId = product.CategoryId,
                CreatedDate = DateTime.Now,
                Description = product.Description,
                ProductName = product.ProductName,
                Price = Convert.ToDecimal(product.Price),
                Recomended = product.Recomended
            };
            _context.Products.Add(_product);
            _context.SaveChanges();
            return _product.Id;
        }

        public int UpdateProduct(ProductViewModel product)
        {
            var _product = _context.Products.Find(product.Id);
            _product.Description = product.Description;
            _product.ProductName = product.ProductName;
            _product.Price = Convert.ToDecimal(product.Price);
            _product.CategoryId = product.CategoryId;
            _product.Recomended = product.Recomended;
            _context.SaveChanges();
            return _product.Id;
        }

        public ProductViewModel EditProduct(int Id)
        {
            var _product = _context.Products.Where(a => a.Id == Id).Include(x => x.Category).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Description = x.Description,
                ProductName = x.ProductName,
                Price = x.Price.ToString(),
                Recomended = x.Recomended,
                CategoryId = x.CategoryId,
                Categories = _category.GetAllCategories(),
            }).FirstOrDefault();
            return _product;
        }

        public void AddImage(ProductPhotosViewModel _photo)
        {
            var products = _context.Products.Find(_photo.ProductId);
            foreach (var photo in _photo.ProductImages)
            {
                var _ImageUrl = _image.UploadImage(photo);
                ProductImages image = new ProductImages()
                {
                    ProductId = _photo.ProductId,
                    ImageUrl = _ImageUrl
                };
                _context.ProductImages.Add(image);
                _context.SaveChanges();
                if (products != null)
                {
                    if (String.IsNullOrEmpty(products.DefaultImageUrl))
                    {
                        products.DefaultImageUrl = _ImageUrl;
                        _context.SaveChanges();
                    }
                }
            }
        }

        public List<ProductPhotosViewModel> ProductPhotoListing(int ProductId)
        {
            return _context.ProductImages.Where(x => x.ProductId == ProductId).AsEnumerable().Select(x => new ProductPhotosViewModel
            {
                ProductId = x.ProductId,
                ProductPhotoId = x.Id,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
        public List<ProductViewModel> GetAllProducts()
        {
            var _data = _context.Products.Include(a => a.Category).Include(x => x.ProductImages).AsEnumerable().Select(x => new ProductViewModel
            {
                Id = x.Id,
                Description = x.Description,
                ProductName = x.ProductName,
                Category = x.Category.CategoryName,
                Recomended = x.Recomended,
                Price = x.Price.ToString(),
                ImageUrl = GetDefaultProductImage(x.Id)
            }).ToList();
            return _data;
        }

        public List<ProductViewModel> GetRecomendedProducts()
        {
            var _data = _context.Products.Where(x => x.Recomended == true).OrderByDescending(x => x.Id).Take(3).Include(a => a.Category).Include(x => x.ProductImages).AsEnumerable().Select(x => new ProductViewModel
            {
                Id = x.Id,
                Description = x.Description,
                ProductName = x.ProductName,
                Category = x.Category.CategoryName,
                Recomended = x.Recomended,
                Price = x.Price.ToString(),
                ImageUrl = GetDefaultProductImage(x.Id)
            }).ToList();
            return _data;
        }

        private string GetDefaultProductImage(int ProductId)
        {
            var _product = _context.ProductImages.Where(x => x.ProductId == ProductId).FirstOrDefault();
            if (_product != null)
            {
                return _product.ImageUrl;

            }
            else
            {
                return "/images/NoImage.png";
            }
        }
        public bool DeleteProduct(int ProductId)
        {
            var _data = _context.Products.Find(ProductId);
            if (_data != null)
            {
                _context.Products.Remove(_data);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteProductImage(int ImageId)
        {
            var _data = _context.ProductImages.Find(ImageId);
            if (_data != null)
            {
                _context.ProductImages.Remove(_data);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IList<ProductViewModel> GetProductListing(ProductsFilterViewModel data)
        {
            var CategorizedProducts = _context.Products.Where(x => x.CategoryId == data.CategoryId).AsEnumerable();

            //Paging
            int counts = CategorizedProducts.Count();
            int TotalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(counts) / 30));

            if (TotalPages < data.PageNumber)
            {
                return new List<ProductViewModel>();
            }


            var finalItems = CategorizedProducts.Skip(data.PageNumber * 30)
                 .Take(30).AsEnumerable().Select(x => new ProductViewModel
                 {
                     Id = x.Id,
                     ProductName = x.ProductName,
                     ImageUrl = GetDefaultProductImage(x.Id),
                     Description = x.Description,
                     Price = x.Price.ToString(),
                     PageSize = TotalPages,
                     TotalRecords = counts,
                 }).ToList();

            return finalItems;

        }

        public ProductViewModel GetItemDetails(int ProductId)
        {
            return _context.Products.Include(x => x.ProductImages).Include(x => x.Category)
                .Where(x => x.Id == ProductId).AsEnumerable().
                Select(x => new ProductViewModel
                {
                    ProductName = x.ProductName,
                    Id = x.Id,
                    ImageUrl = GetDefaultProductImage(x.Id),
                    Description = x.Description,
                    Price = x.Price.ToString(),
                    Images = x.ProductImages.Select(a => a.ImageUrl).ToList(),
                    Category = x.Category.CategoryName,
                    CategoryId = x.CategoryId
                }).FirstOrDefault();
        }
        public IList<ProductViewModel> GetLatestProductListing()
        {
            var finalItems = _context.Products.Where(x => x.Recomended == true).OrderBy(x => x.Id).Take(8)
            .AsEnumerable().Select(x => new ProductViewModel
            {
                Id = x.Id,
                ProductName = x.ProductName,
                ImageUrl = GetDefaultProductImage(x.Id),
                Description = x.Description,
                Price = x.Price.ToString(),
            }).ToList();
            return finalItems;
        }

        public List<ProductViewModel> SearchProducts(string query, string category)
        {
            if (String.IsNullOrEmpty(category))
            {
                return _context.Products.OrderByDescending(x => x.Id).Include(x => x.Category).
                    Where(c => EF.Functions.Like(c.ProductName, query + "%")).AsEnumerable().Select(x => new ProductViewModel
                    {
                        Id = x.Id,
                        ProductName = x.ProductName,
                        ImageUrl = GetDefaultProductImage(x.Id),
                        Description = x.Description,
                        Price = x.Price.ToString(),
                    }).ToList();
            }
            else
            {
                int categoryId = Convert.ToInt32(category);
                return _context.Products.OrderByDescending(x => x.Id).Include(x => x.Category)
                    .Where(c => c.CategoryId == categoryId && EF.Functions.Like(c.ProductName, query + "%")).AsEnumerable().Select(x => new ProductViewModel
                    {
                        Id = x.Id,
                        ProductName = x.ProductName,
                        ImageUrl = GetDefaultProductImage(x.Id),
                        Description = x.Description,
                        Price = x.Price.ToString(),
                    }).ToList();
            }
        }
    }
}
