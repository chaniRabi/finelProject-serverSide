using DAL.Models;

namespace DAL
{
    public interface IOrderDL
    {
       public Task<Order> AddOrder(Order order);
       public Task<Order> GetOrderById(int id);
       public Task<List<Order>> GetOrders();
       public Task<bool> RemoveOrder(int id);
       public Task<Order> Update(Order order, int id);
    }
}