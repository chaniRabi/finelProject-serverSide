using DAL.Models;
using Entities.DTO;

namespace BL
{
    public interface IProductInCartBL
    {
       public Task<ProductInCartDTO> AddProductToCart(ProductInCartDTO itemToBag);

       public Task<bool> ClaerCart(int userId);
        public Task<List<ProductInCartDTO>> GetProductsInCartByUserId(int userId);
       public Task<ProductInCartDTO> GetCartById(int id);
        public Task<bool> RemoveProductFromCart(int id);
       public Task<ProductInCartDTO> UpdateCart(ProductInCartDTO bag, int id);
    }
}