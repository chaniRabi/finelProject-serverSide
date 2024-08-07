using DAL.Models;

namespace DAL
{
    public interface IProductDL
    {
        Task<Product> AddProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetProductsByCategoryId(int categoryId);
        Task<bool> RemoveProduct(int id);
        Task<Product> UpdateProduct(Product product, int id);
        Task UpdateStock(int productId, int quantity);
    }
}