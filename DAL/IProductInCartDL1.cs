using DAL.Models;

namespace DAL
{
    public interface IProductInCartDL1
    {
       public Task<ProductInCart> AddProductToCart(ProductInCart itemToBag);
       public Task<bool> ClearCart(int userId);
       public Task<ProductInCart> GetCartById(int id);
       public Task<List<ProductInCart>> GetProductsInCartByUserId(int userId);
      public  Task<bool> RemoveProductFromCart(int id);
      public  Task<ProductInCart> UpdateCart(ProductInCart bag, int id);
    }
}