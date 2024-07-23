using BL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Entities.DTO;
using System.Collections.Generic;
using DAL;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ShineStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInCartController : ControllerBase
    {
        private IProductInCartBL _ProductInCartBL;
        private object _ProductBL;

        public ProductInCartController(IProductInCartBL bagBL)
        {
            _ProductInCartBL = bagBL;
        }

        //GET: api/<BagController>
        [HttpGet("GetProductsInCartByUserId/{userId}")]
        public async Task<List<Product>> GetProductsInCartByUserId(int userId)
        {
            var products = await _ProductInCartBL.GetProductsInCartByUserId(userId);
            //if (products == null)
            //{
            //    return NotFound();
            //}

            return products;
        }

        // GET api/<BagController>/5
        [HttpGet("{id}")]
        public async Task<ProductInCart> GetCartById(int id)
        {
            ProductInCart current = await _ProductInCartBL.GetCartById(id);
            return current;
        }

        //POST api/<BagController>
        [HttpPost]
        public async Task<ActionResult<ProductInCartDTO>> AddProductToCart([FromBody] ProductInCartDTO itemToBag)
        {
            try
            {
                ProductInCartDTO isAddToBag = await _ProductInCartBL.AddProductToCart(itemToBag);
                return isAddToBag;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        // PUT api/<BagController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductInCartDTO>> UpdateCart([FromBody] ProductInCartDTO bag, int id)
        {
            try
            {
                ProductInCartDTO UpdateBag = await _ProductInCartBL.UpdateCart(bag, id);
                if (UpdateBag != null)
                    return Ok(bag);
                return BadRequest();

            }
            catch (Exception ex)
            {
                string modifiedMessage = ex.Message + "somthing went wrong";
                throw new Exception(modifiedMessage);
            }
        }

        // DELETE api/<BagController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemoveProductFromCart(int id)
        {
            try
            {
                bool isRmoved = await _ProductInCartBL.RemoveProductFromCart(id);
                return isRmoved;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        [HttpDelete("clearCart/{userId}")]
        public async Task<ActionResult<bool>> ClearCart(int userId)
        {
            try
            {
                bool isCleared = await _ProductInCartBL.ClaerCart(userId);
                return isCleared;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
