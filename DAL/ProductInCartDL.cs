using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProductInCartDL : IProductInCartDL1
    {

        private ShinestockContext _context;

        public ProductInCartDL(ShinestockContext context)
        {
            _context = context;
        }

        //public async Task<List<Product>> GetProductsInCartByUserId(int userId)
        //{
        //    var inBug = await _context.ProductInCarts.Where();//מחפש את המוצר שבעגלה ששייכת לאותו יוזר שקיבלתי

        //    return inBug;
        //}

        //הפונקציה GetProductsInCartByUserId מטרתה להחזיר רשימה של מוצרים שנמצאים בעגלת הקניות של משתמש מסוים על פי ה-UserId.
        public async Task<List<Product>> GetProductsInCartByUserId(int userId)
        {
            var products = await (from c in _context.ProductInCarts
                                  join p in _context.Products on c.ProductId equals p.Id
                                  where c.CustomerId == userId
                                  select new Product
                                  {
                                      Id = p.Id,
                                      Name = p.Name,
                                      Price = p.Price,
                                      CategoryId = p.CategoryId,
                                      Image = p.Image,
                                      Description = p.Description,
                                      ProductInCarts = _context.ProductInCarts
                                                            .Where(pc => pc.CustomerId == userId && pc.ProductId == p.Id)
                                                            .Select(pc => new ProductInCart
                                                            {
                                                                Id = pc.Id,
                                                                Amount = pc.Amount ?? 0
                                                            })
                                                            .ToList()
                                  }).ToListAsync();

            return products;
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
                ProductInCart current = await _context.ProductInCarts.FirstOrDefaultAsync(item => item.ProductId == id && item.CustomerId == bag.CustomerId);
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

        public async Task<bool> ClearCart(int userId)
        {
            try
            {
                var itemsToRemove = await _context.ProductInCarts
                                                 .Where(p => p.CustomerId == userId)
                                                 .ToListAsync();

                _context.ProductInCarts.RemoveRange(itemsToRemove);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
    }
    };


