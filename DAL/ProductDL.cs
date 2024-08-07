using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProductDL : IProductDL
    {
        public ShinestockContext _context;
        public ProductDL(ShinestockContext context) { _context = context; }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return products;
        }

        //public async Task<List<Product>> GetProducts(int categoryId)
        //{

        //    return await _context.Products
        //                     .Where(p => p.CategoryId == categoryId)
        //                     .ToListAsync();
        //}

        public async Task<Product> GetProductById(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product.Id == id) { return product; }
            return null;
        }

        public async Task<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await _context.Products
                                 .Where(p => p.CategoryId == categoryId)
                                 .ToListAsync();

        }

        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> RemoveProduct(int id)
        {
            try
            {
                Product product = await _context.Products.SingleOrDefaultAsync(item => item.Id == id);
                if (product == null)
                {
                    throw new ArgumentException($"{id} is not found");
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> UpdateProduct(Product product, int id)
        {
            try
            {
                Product current = await _context.Products.FirstOrDefaultAsync(item => item.Id == id);
                if (current != null)
                {
                    current.Name = product.Name;
                    current.Price = product.Price;
                    current.CategoryId = product.CategoryId;
                    current.Quantity = product.Quantity;
                    current.Image = product.Image;
                    current.Description = product.Description;

                    _context.Products.Update(current);
                    await _context.SaveChangesAsync();
                    return current;
                }
                else
                    return null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task UpdateStock(int productId, int quantity)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == productId);
            if (product != null)
            {
                product.Quantity = quantity;
                await _context.SaveChangesAsync();
            }
            //void אין צורך להחזיר ערך כאן כי זה פונקצית 

        }
    }
}
