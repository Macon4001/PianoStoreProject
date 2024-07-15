using PianoStoreProject.Models;
using System.Collections.Generic;

namespace PianoStoreProject.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(CategoriesViewModel category);
        void UpdateCategory(CategoriesViewModel category);
        bool DeleteCategory(int id);
        List<CategoriesViewModel> GetAllCategories();
        List<CategoriesViewModel> GetPopularCategories();
        CategoriesViewModel EditCategory(int Id);
        List<CategoriesViewModel> GetSelectedCategories();
        List<CategoriesViewModel> GetMenuCategories();
        public string GetCategoryName(int CategoryID);
    }
}
