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
    public class OrdersProductBL : IOrdersProductBL
    {
        IOrdersProductDL _orderProductDL;
        IMapper _mapper;

        public OrdersProductBL(IOrdersProductDL orderProductDL, IMapper mapper)
        {
            _orderProductDL = orderProductDL;
            _mapper = mapper;
        }

        public async Task<List<OrdersProduct>> GetOrdersProducts()
        {
            List<OrdersProduct> orders = await _orderProductDL.GetOrdersProduct();
            return orders;
        }
        public async Task<OrdersProduct> GetOrdersProductById(int id)
        {
            OrdersProduct currentOrdersProduct = await _orderProductDL.GetOrdersProductById(id);
            return currentOrdersProduct;
        }

        public async Task<OrdersProductDTO> AddOrdersProduct(OrdersProductDTO order)
        {
            OrdersProduct u = _mapper.Map<OrdersProduct>(order);
            OrdersProduct isAdd = await _orderProductDL.AddOrdersProduct(u);
            OrdersProductDTO orderDTO = _mapper.Map<OrdersProductDTO>(isAdd);
            return orderDTO;
        }
        public async Task<bool> RemoveOrdersProduct(int id)
        {
            int u = _mapper.Map<int>(id);
            bool isRmove = await _orderProductDL.RemoveOrderProduct(u);
            return isRmove;
        }

        //public async Task<OrdersProductDTO> Update(OrdersProductDTO order, int id)
        //{
        //    OrdersProduct u = _mapper.Map<OrdersProduct>(order);
        //    OrdersProduct updatedOrder = await _orderProductDL.Update(u, id);
        //    OrdersProductDTO orderDTO = _mapper.Map<OrdersProductDTO>(updatedOrdersProduct);

        //    return OrdersProductDTO;

        //}
    }
}
