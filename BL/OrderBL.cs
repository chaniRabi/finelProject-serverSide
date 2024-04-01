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
    public class OrderBL : IOrderBL
    {
        IOrderDL _orderDL;
        IMapper _mapper;

        public OrderBL(IOrderDL orderDL, IMapper mapper)
        {
            _orderDL = orderDL;
            _mapper = mapper;
        }

        public async Task<List<Order>> GetOrders()
        {
            List<Order> orders = await _orderDL.GetOrders();
            return orders;
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
    }
}
