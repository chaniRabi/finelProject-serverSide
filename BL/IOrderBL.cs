using DAL.Models;
using Entities.DTO;

namespace BL
{
    public interface IOrderBL
    {
      public  Task<OrderDTO> AddOrder(OrderDTO order);
      public  Task<Order> GetOrderById(int id);
      public  Task<List<OrderDTO>> GetOrders();
      public  Task<bool> RemoveOrder(int id);
      public  Task<OrderDTO> Update(OrderDTO order, int id);
        public Task ProcessOrderAsync(OrderDTO order);
    }
}