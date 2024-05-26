using AutoMapper;
using DAL;
using DAL.Models;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductBL : IProductBL
    {
        IProductDL _productDL;
        IMapper _mapper;

        public ProductBL(IProductDL productDL, IMapper mapper)
        {
            _productDL = productDL;
            _mapper = mapper;
        }
        public async Task<List<Product>> GetProduct()
        {
            List<Product> users = await _productDL.GetProducts();
            return users;
        }
        public async Task<Product> GetProductById(int id)
        {
            Product currentProduct = await _productDL.GetProductById(id);
            return currentProduct;
        }
        public async Task<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await _productDL.GetProductsByCategoryId(categoryId);
        }
        public async Task<ProductDTO> AddProduct(ProductDTO product)
        {
            Product u = _mapper.Map<Product>(product);
            Product isAdd = await _productDL.AddProduct(u);
            ProductDTO userDTO = _mapper.Map<ProductDTO>(isAdd);
            return userDTO;
        }
        public async Task<bool> RemoveProduct(int id)
        {
            int u = _mapper.Map<int>(id);
            bool isRmove = await _productDL.RemoveProduct(u);
            return isRmove;
        }

        public async Task<ProductDTO> Update(ProductDTO product, int id)
        {
            Product u = _mapper.Map<Product>(product);
            Product updatedProduc = await _productDL.UpdateProduct(u, id);
            ProductDTO userDTO = _mapper.Map<ProductDTO>(updatedProduc);

            return userDTO;

        }
    }
}
