using DAL.Models;

namespace DAL
{
    public interface IProductInCartDL
    {
        Task<ProductInCart> AddProductToCart(ProductInCart itemToBag);
        Task<List<Product>> GetProductsInCartByUserId(int userId);
        Task<ProductInCart> GetCartById(int id);
        Task<bool> RemoveProductFromCart(int id);
        Task<ProductInCart> UpdateCart(ProductInCart bag, int id);
    }
}