using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrdersProductDL : IOrdersProductDL
    {
        public ShinestockContext _context;
        public OrdersProductDL(ShinestockContext context)
        {
            _context = context;
        }

        public async Task<List<OrdersProduct>> GetOrdersProduct()
        {
            List<OrdersProduct> items = await _context.OrdersProducts.ToListAsync();
            return items;
        }

        public async Task<OrdersProduct> GetOrdersProductById(int id)
        {
            OrdersProduct currentOrdersProduct = await _context.OrdersProducts.FindAsync(id);
            if (currentOrdersProduct.Id == id)
                return currentOrdersProduct;
            return null;
        }

        public async Task<OrdersProduct> AddOrdersProduct(OrdersProduct item)
        {
            try
            {
                await _context.OrdersProducts.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveOrderProduct(int id)
        {
            try
            {
                OrdersProduct currentOrdersProduct = await _context.OrdersProducts.SingleOrDefaultAsync(item => item.Id == id);
                if (currentOrdersProduct == null)
                {
                    throw new ArgumentException($"{id} is not found");
                }
                _context.OrdersProducts.Remove(currentOrdersProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<OrdersProduct> Update(OrdersProduct item, int id)
        //{
        //    try
        //    {
        //        OrdersProduct current = await _context.OrdersProducts.FirstOrDefaultAsync(item => item.Id == id);
        //        if (current != null)
        //        {



        //            _context.OrdersProducts.Update(current);
        //            _context.Entry(user).State = EntityState.Modified; //מעדכן את הדטהבייס
        //            await _context.SaveChangesAsync();
        //            return current;
        //        }
        //        else
        //            return null;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
