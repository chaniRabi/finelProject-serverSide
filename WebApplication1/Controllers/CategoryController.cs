using BL;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using Entities.DTO;
using DAL;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ShineStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryBL _categoryBL;

        public CategoryController(ICategoryBL categoryBL)
        {
            _categoryBL = categoryBL;
        }

        [HttpGet]
        [Route("GetCategories")]

        public async Task<List<Category>> GetCategories()
        {
            var Category = await _categoryBL.GetCategories();
            return Category;
        }

        [HttpGet]
        [Route("getCategoryById/{id}")]
        public async Task<Category> GetCategoryById(int id)
        {
            Category category = await _categoryBL.GetCategoryById(id);
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> AddOrder([FromBody] CategoryDTO category)
        {
            try
            {
                CategoryDTO isAddCategory = await _categoryBL.AddCategory(category);
                return isAddCategory;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> RemoveCategory([FromBody] int id)
        {
            try
            {
                bool isRmoveCategory = await _categoryBL.RemoveCategory(id);
                return isRmoveCategory;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> Update([FromBody] CategoryDTO category, int id)
        {
            try
            {
                CategoryDTO updatedCategory = await _categoryBL.Update(category, id);
                if (updatedCategory != null)
                    return Ok(category);
                return BadRequest();

            }
            catch (Exception ex)
            {
                string modifiedMessage = ex.Message + "somthing went wrong";
                throw new Exception(modifiedMessage);
            }

        }
    }
}
