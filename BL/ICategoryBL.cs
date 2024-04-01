using DAL.Models;
using Entities.DTO;

namespace BL
{
    public interface ICategoryBL
    {
        public Task<CategoryDTO> AddCategory(CategoryDTO category);
        public Task<List<Category>> GetCategories();
        public Task<Category> GetCategoryById(int id);
        public Task<bool> RemoveCategory(int id);
        public Task<CategoryDTO> Update(CategoryDTO category, int id);
    }
}