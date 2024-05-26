using DAL;
using DAL.Models;
using Entities.DTO;
using AutoMapper;

namespace BL
{
    public class ProductInCartBL : IProductInCartBL
    {
        IProductInCartDL _ProductInCartDL;
        IMapper _mapper;

        public ProductInCartBL(IProductInCartDL bagDL, IMapper mapper)
        {
            _ProductInCartDL = bagDL;
            _mapper = mapper;

        }

        public async Task<List<Product>> GetProductsInCartByUserId(int userId)
        {
            List<Product> items = await _ProductInCartDL.GetProductsInCartByUserId(userId);
            return items;
        }
        public async Task<ProductInCart> GetCartById(int id)
        {
            ProductInCart currentBag = await _ProductInCartDL.GetCartById(id);
            return currentBag;
        }

        public async Task<ProductInCartDTO> AddProductToCart(ProductInCartDTO itemToBag)
        {
            ProductInCart u = _mapper.Map<ProductInCart>(itemToBag);
            ProductInCart isAdd = await _ProductInCartDL.AddProductToCart(u);
            ProductInCartDTO productInCartDTO = _mapper.Map<ProductInCartDTO>(itemToBag);
            return productInCartDTO;
        }
        public async Task<bool> RemoveProductFromCart(int id)
        {
            int u = _mapper.Map<int>(id);
            bool isRmove = await _ProductInCartDL.RemoveProductFromCart(u);
            return isRmove;
        }

        public async Task<ProductInCartDTO> UpdateCart(ProductInCartDTO bag, int id)
        {
            ProductInCart u = _mapper.Map<ProductInCart>(bag);
            ProductInCart isUpdate = await _ProductInCartDL.UpdateCart(u, id);
            ProductInCartDTO productInCartDTO = _mapper.Map<ProductInCartDTO>(bag);
            return productInCartDTO;

        }
    }
}
