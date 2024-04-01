using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using BL;
using DAL;
using Entities.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ShineStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductBL _productBL;

        public ProductController(IProductBL productBL)
        {
            _productBL = productBL;
        }
        [HttpGet]
        [Route("getProduct")]
        public async Task<List<Product>> GetProduct()
        {
            var Product = await _productBL.GetProduct();
            return Product;
        }

        [HttpGet]
        [Route("getProductById/{id}")]
        public async Task<Product> GetProductById(int id)
        {
            Product currentProduct = await _productBL.GetProductById(id);
            return currentProduct;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> AddProduct([FromBody] ProductDTO product)
        {
            try
            {
                ProductDTO isAddProduct = await _productBL.AddProduct(product);
                return isAddProduct;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> RemoveProduct([FromBody] int id)
        {
            try
            {
                bool isRmoveProduct = await _productBL.RemoveProduct(id);
                return isRmoveProduct;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> Update([FromBody] ProductDTO product, int id)
        {
            try
            {
                ProductDTO updatedProduct = await _productBL.Update(product, id);
                if (updatedProduct != null)
                    return Ok(product);
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
