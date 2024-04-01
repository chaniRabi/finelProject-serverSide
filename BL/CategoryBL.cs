using AutoMapper;
using DAL.Models;
using DAL;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoryBL : ICategoryBL
    {
        ICategoryDL _categoryDL;
        IMapper _mapper;

        public CategoryBL(ICategoryDL categoryDL, IMapper mapper)
        {
            _categoryDL = categoryDL;
            _mapper = mapper;
        }

        public async Task<List<Category>> GetCategories()
        {
            List<Category> Categories = await _categoryDL.GetCategories();
            return Categories;
        }
        public async Task<Category> GetCategoryById(int id)
        {
            Category currentCategory = await _categoryDL.GetCategoryById(id);
            return currentCategory;
        }

        public async Task<CategoryDTO> AddCategory(CategoryDTO category)
        {
            Category u = _mapper.Map<Category>(category);
            Category isAdd = await _categoryDL.AddCategory(u);
            CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(isAdd);
            return categoryDTO;
        }
        public async Task<bool> RemoveCategory(int id)
        {
            int u = _mapper.Map<int>(id);
            bool isRmove = await _categoryDL.RemoveCategory(u);
            return isRmove;
        }

        public async Task<CategoryDTO> Update(CategoryDTO category, int id)
        {
            Category u = _mapper.Map<Category>(category);
            Category updatedCategory = await _categoryDL.Update(u, id);
            CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(updatedCategory);

            return categoryDTO;

        }
    }
}
