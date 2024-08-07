using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using BL;
using DAL;
using Entities.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ShineStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderBL _orderBL;

        public OrderController(IOrderBL orderBL)
        {
            _orderBL = orderBL;
        }

        [HttpGet]
        [Route("getOrders")]

        public async Task<List<OrderDTO>> GetOrders()
        {
            var Orders = await _orderBL.GetOrders();
            return Orders;
        }

        [HttpGet]
        [Route("getOrderById/{id}")]
        public async Task<Order> GetOrderById(int id)
        {
            Order currentOrder = await _orderBL.GetOrderById(id);
            return currentOrder;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder([FromBody] OrderDTO order)
        {
            try
            {
                OrderDTO isAddOrder = await _orderBL.AddOrder(order);
                return Ok(isAddOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> RemoveOrder([FromBody] int id)
        {
            try
            {
                bool isRmoveOrder = await _orderBL.RemoveOrder(id);
                return isRmoveOrder;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDTO>> Update([FromBody] OrderDTO order, int id)
        {
            try
            {
                OrderDTO updatedOrder = await _orderBL.Update(order, id);
                if (updatedOrder != null)
                    return Ok(order);
                return BadRequest();

            }
            catch (Exception ex)
            {
                string modifiedMessage = ex.Message + "somthing went wrong";
                throw new Exception(modifiedMessage);
            }

        }

        //[HttpPost("{}")]
        //public async Task<ActionResult<OrderDTO>> PlaceOrder([FromBody] OrderDTO order)
        //{
        //    if (order == null)
        //    {
        //        return BadRequest("Invalid order data.");
        //    }
        //    await _orderBL.ProcessOrderAsync(order);
        //    return Ok(order);


        //}
    }
}
