using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProductInCartDL : IProductInCartDL
    {

        private ShinestockContext _context;

        public ProductInCartDL(ShinestockContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsInCartByUserId()
        {
            List<Product> inBug = await _context.Products.ToListAsync();
            return inBug;
        }

        public async Task<ProductInCart> GetCartById(int id)
        {
            ProductInCart currentBag = await _context.ProductInCarts.FindAsync(id);
            if (currentBag.Id == id)
                return currentBag;
            return null;
        }

        public async Task<ProductInCart> AddProductToCart(ProductInCart itemToBag)
        {
            try
            {
                await _context.ProductInCarts.AddAsync(itemToBag);
                await _context.SaveChangesAsync();
                return itemToBag;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }
        }

        public async Task<bool> RemoveProductFromCart(int id)
        {
            try
            {
                ProductInCart currentProduct = await _context.ProductInCarts.SingleOrDefaultAsync(item => item.Id == id);
                if (currentProduct == null)
                {
                    throw new ArgumentException($"{id} is not found");
                }
                _context.ProductInCarts.Remove(currentProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductInCart> UpdateCart(ProductInCart bag, int id)
        {
            try
            {
                ProductInCart current = await _context.ProductInCarts.FirstOrDefaultAsync(item => item.Id == id);
                if (current != null)
                {
                    current.Amount = bag.Amount;

                    _context.ProductInCarts.Update(current);
                    //_context.Entry(user).State = EntityState.Modified; //מעדכן את הדטהבייס
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


