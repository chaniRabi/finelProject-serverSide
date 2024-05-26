using DAL.Models;

namespace DAL
{
    public interface IProductDL
    {
       public Task<Product> AddProduct(Product product);
       public Task<Product> GetProductById(int id);
       public Task<List<Product>> GetProducts();

       public  Task<List<Product>> GetProductsByCategoryId(int categoryId);

       public Task<bool> RemoveProduct(int id);
       public Task<Product> UpdateProduct(Product product, int id);
    }
}