using DAL.Models;
using Entities.DTO;

namespace BL
{
    public interface IOrdersProductBL
    {
       public Task<OrdersProductDTO> AddOrdersProduct(OrdersProductDTO order);
       public Task<OrdersProduct> GetOrdersProductById(int id);
       public Task<List<OrdersProduct>> GetOrdersProducts();
       public Task<bool> RemoveOrdersProduct(int id);
    }
}