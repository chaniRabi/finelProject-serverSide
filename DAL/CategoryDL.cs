using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class CategoryDL : ICategoryDL
    {
        public ShinestockContext _context;
        public CategoryDL(ShinestockContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategories()
        {
            List<Category> Categories = await _context.Categories.ToListAsync();
            return Categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            Category currentCategory = await _context.Categories.FindAsync(id);
            if (currentCategory.Id == id)
                return currentCategory;
            return null;
        }

        public async Task<Category> AddCategory(Category category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveCategory(int id)
        {
            try
            {
                Category currentCategory = await _context.Categories.SingleOrDefaultAsync(item => item.Id == id);
                if (currentCategory == null)
                {
                    throw new ArgumentException($"{id} is not found");
                }
                _context.Categories.Remove(currentCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> Update(Category category, int id)
        {
            try
            {
                Category current = await _context.Categories.FirstOrDefaultAsync(item => item.Id == id);
                if (current != null)
                {
                    current.Id = category.Id;


                    _context.Categories.Update(current);
                   // _context.Entry(user).State = EntityState.Modified; //מעדכן את הדטהבייס
                    await _context.SaveChangesAsync();
                    return current;
                }
                else
                    return null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
