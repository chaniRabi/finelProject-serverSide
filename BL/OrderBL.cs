using AutoMapper;
using DAL.Models;
using DAL;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class OrderBL : IOrderBL
    {
        //קבלת תלות מהשכבות
        IOrderDL _orderDL;
        IMapper _mapper;
        IProductDL _productDL;

        public OrderBL(IOrderDL orderDL, IMapper mapper, IProductDL productDL)
        {
            _orderDL = orderDL;
            _mapper = mapper;
            _productDL = productDL;
            

        }

        public async Task<List<OrderDTO>> GetOrders()
        {
            List<Order> orders = await _orderDL.GetOrders();
            List<OrderDTO> orderDTO = _mapper.Map<List<OrderDTO>>(orders);
            return orderDTO;
        }
        public async Task<Order> GetOrderById(int id)
        {
            Order currentOrder = await _orderDL.GetOrderById(id);
            return currentOrder;
        }

        public async Task<OrderDTO> AddOrder(OrderDTO order)
        {
            Order u = _mapper.Map<Order>(order);
            Order isAdd = await _orderDL.AddOrder(u);
            OrderDTO orderDTO = _mapper.Map<OrderDTO>(isAdd);
             await ProcessOrderAsync(order);
            return orderDTO;
        }
        public async Task<bool> RemoveOrder(int id)
        {
            int u = _mapper.Map<int>(id);
            bool isRmove = await _orderDL.RemoveOrder(u);
            return isRmove;
        }

        public async Task<OrderDTO> Update(OrderDTO order, int id)
        {
            Order u = _mapper.Map<Order>(order);
            Order updatedOrder = await _orderDL.Update(u, id);
            OrderDTO orderDTO = _mapper.Map<OrderDTO>(updatedOrder);

            return orderDTO;

        }

        public async Task ProcessOrderAsync(OrderDTO order)
        {
            foreach (var item in order.OrdersProducts)
            {
                await _productDL.UpdateStock(item.ProductId, item.Amount);
            }
        }
    }
}
