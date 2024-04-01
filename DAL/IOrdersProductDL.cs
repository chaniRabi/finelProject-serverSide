using DAL.Models;

namespace DAL
{
    public interface IOrdersProductDL
    {
       public Task<OrdersProduct> AddOrdersProduct(OrdersProduct item);
       public  Task<List<OrdersProduct>> GetOrdersProduct();
       public Task<OrdersProduct> GetOrdersProductById(int id);
       public Task<bool> RemoveOrderProduct(int id);
    }
}