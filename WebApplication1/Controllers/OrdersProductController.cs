using AutoMapper;
using BL;
using DAL;
using DAL.Models;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ShineStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersProductController : ControllerBase
    {
        IOrdersProductBL _orderProductBL;

        public OrdersProductController(IOrdersProductBL ordersProductBL)
        {
            _orderProductBL = ordersProductBL;
        }

        [HttpGet]
        [Route("getOrdersProducts")]
        public async Task<List<OrdersProduct>> GetOrdersProducts()
        {
            var OrdersProduct = await _orderProductBL.GetOrdersProducts();
            return OrdersProduct;
        }

        [HttpGet]
        [Route("getOrdersProductById/{id}")]
        public async Task<OrdersProduct> GetOrdersProductById(int id)
        {
            OrdersProduct current = await _orderProductBL.GetOrdersProductById(id);
            return current;
        }

        [HttpPost]
        public async Task<ActionResult<OrdersProductDTO>> AddOrderProduct([FromBody] OrdersProductDTO orderProduct)
        {
            try
            {
                OrdersProductDTO isAddOrderProduct = await _orderProductBL.AddOrdersProduct(orderProduct);
                return isAddOrderProduct;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> RemoveOrdersProduct([FromBody] int id)
        {
            try
            {
                bool isRmoveOrdersProduct = await _orderProductBL.RemoveOrdersProduct(id);
                return isRmoveOrdersProduct;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
