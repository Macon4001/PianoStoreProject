using PianoStoreProject.Data;
using PianoStoreProject.Models;
using PianoStoreProject.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PianoStoreProject.Providers
{
    public class CategoryProvider : ICategoryRepository
    {
        private IImageRepository _image { get; set; }
        private PSPDBContext _context { get; }
        public CategoryProvider(PSPDBContext context, IImageRepository image)
        {
            _image = image;
            _context = context;
        }
        public void AddCategory(CategoriesViewModel category)
        {
            string _imageUrl = _image.UploadImage(category.CategoryImage);
            Category _category = new Category()
            {
                CategoryName = category.CategoryName,
                Description = category.Description,
                CategoryImageUrl = _imageUrl,
            };
            _context.Category.Add(_category);
            _context.SaveChanges();
        }
        public void UpdateCategory(CategoriesViewModel category)
        {
            var _category = _context.Category.Find(category.Id);
            string _imageUrl = "";

            if (category.CategoryImage != null)
            {
                _imageUrl = _image.UploadImage(category.CategoryImage);

            }
            else
            {
                if (!string.IsNullOrEmpty(category.CategoryImageUrl))
                {
                    _imageUrl = category.CategoryImageUrl;
                }
            }

            if (_category != null)
            {
                if (!string.IsNullOrEmpty(_imageUrl))
                {
                    _category.CategoryImageUrl = _imageUrl;
                }
                _category.CategoryName = category.CategoryName;
                _category.Description = category.Description;
                _context.SaveChanges();
            }
        }
        public bool DeleteCategory(int id)
        {
            var item = _context.Category.Find(id);
            if (item != null)
            {
                _context.Category.Remove(item);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public CategoriesViewModel EditCategory(int Id)
        {
            CategoriesViewModel category = new CategoriesViewModel();
            var _category = _context.Category.Find(Id);
            if (_category != null)
            {
                category.Id = _category.Id;
                category.CategoryName = _category.CategoryName;
                category.Description = _category.Description;
                category.CategoryImageUrl = _category.CategoryImageUrl;
            }
            return category;
        }
        public string GetCategoryName(int CategoryID)
        {
            var data = _context.Category.Where(x => x.Id == CategoryID).AsEnumerable().Select(x => x.CategoryName).FirstOrDefault().ToString();
            return data;
        }
        public List<CategoriesViewModel> GetAllCategories()
        {
            var _data = _context.Category.AsEnumerable().Select(x => new CategoriesViewModel
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                Id = x.Id,
                CategoryImageUrl = x.CategoryImageUrl
            }).ToList();
            return _data;
        }
        public List<CategoriesViewModel> GetPopularCategories()
        {
            var _data = _context.Category.AsEnumerable().Take(3).Select(x => new CategoriesViewModel
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                Id = x.Id,
                CategoryImageUrl = x.CategoryImageUrl
            }).ToList();
            return _data;
        }
        public List<CategoriesViewModel> GetMenuCategories()
        {
            var _data = _context.Category.AsEnumerable().Take(9).Select(x => new CategoriesViewModel
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                Id = x.Id,
                CategoryImageUrl = x.CategoryImageUrl
            }).ToList();
            return _data;
        }
        public List<CategoriesViewModel> GetSelectedCategories()
        {
            return _context.Category.OrderBy(x => x.Id).Take(3).AsEnumerable().Select(x => new CategoriesViewModel
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                Id = x.Id,
                CategoryImageUrl = x.CategoryImageUrl
            }).ToList();
        }
    }
}
