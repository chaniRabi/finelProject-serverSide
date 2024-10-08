﻿using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDL : IOrderDL
    {
        public ShinestockContext _context;
        public OrderDL(ShinestockContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrders()
        {
            List<Order> orders = await _context.Orders.Include(x => x.OrdersProducts).ThenInclude(y => y.Product).ToListAsync();
            return orders;
        }

        public async Task<Order> GetOrderById(int id)
        {
            Order currentOrder = await _context.Orders.FindAsync(id);
            if (currentOrder.Id == id)
                return currentOrder;
            return null;
        }

        public async Task<Order> AddOrder(Order order)
        {
            try
            {
                var productInCarts = await _context.ProductInCarts.Where(x => x.CustomerId == order.UserId).ToListAsync();
                //Add the order including related OrderProducts
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync(); // Save changes to generate the OrderId
                
                _context.ProductInCarts.RemoveRange(productInCarts);
                await _context.SaveChangesAsync();

                return order;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while adding the order.", ex);
            }
        }


        public async Task<bool> RemoveOrder(int id)
        {
            try
            {
                Order currentOrder = await _context.Orders.SingleOrDefaultAsync(item => item.Id == id);
                if (currentOrder == null)
                {
                    throw new ArgumentException($"{id} is not found");
                }
                _context.Orders.Remove(currentOrder);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> Update(Order order, int id)
        {
            try
            {
                Order current = await _context.Orders.FirstOrDefaultAsync(item => item.Id == id);
                if (current != null)
                {
                    current.StatusId = order.StatusId;


                    _context.Orders.Update(current);
                    // _context.Entry(user).State = EntityState.Modified; //מעדכן את הדטהבייס
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


    }
}
