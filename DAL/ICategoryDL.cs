using DAL.Models;

namespace DAL
{
    public interface ICategoryDL
    {
        public Task<Category> AddCategory(Category category);
        public Task<List<Category>> GetCategories();
        public Task<Category> GetCategoryById(int id);
        public Task<bool> RemoveCategory(int id);
        public Task<Category> Update(Category category, int id);
    }
}