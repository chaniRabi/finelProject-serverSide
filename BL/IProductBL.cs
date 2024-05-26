using DAL.Models;
using Entities.DTO;

namespace BL
{
    public interface IProductBL
    {
      public  Task<ProductDTO> AddProduct(ProductDTO product);
      public  Task<List<Product>> GetProduct();
      public  Task<Product> GetProductById(int id);
        public Task<List<Product>> GetProductsByCategoryId(int categoryId);
      public  Task<bool> RemoveProduct(int id);
      public  Task<ProductDTO> Update(ProductDTO product, int id);
    }
}