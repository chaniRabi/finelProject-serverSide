using DAL;
using DAL.Models;
using Entities.DTO;
using AutoMapper;

namespace BL
{
    public class ProductInCartBL : IProductInCartBL
    {
        IProductInCartDL1 _ProductInCartDL;
        IMapper _mapper;

        public ProductInCartBL(IProductInCartDL1 bagDL, IMapper mapper)
        {
            _ProductInCartDL = bagDL;
            _mapper = mapper;

        }

        public async Task<List<ProductInCartDTO>> GetProductsInCartByUserId(int userId)
        {
            List<ProductInCart> items = await _ProductInCartDL.GetProductsInCartByUserId(userId);
            List<ProductInCartDTO> productInCartDTO = _mapper.Map<List<ProductInCartDTO>>(items);
            return productInCartDTO;
        }
        public async Task<ProductInCartDTO> GetCartById(int id)
        {
            ProductInCart currentBag = await _ProductInCartDL.GetCartById(id);
            ProductInCartDTO productInCartDTO = _mapper.Map<ProductInCartDTO>(currentBag);
            return productInCartDTO;
        }

        public async Task<ProductInCartDTO> AddProductToCart(ProductInCartDTO itemToBag)
        {
            ProductInCart u = _mapper.Map<ProductInCart>(itemToBag);
            ProductInCart isAdd = await _ProductInCartDL.AddProductToCart(u);
            ProductInCartDTO productInCartDTO = _mapper.Map<ProductInCartDTO>(isAdd);
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
            ProductInCartDTO productInCartDTO = _mapper.Map<ProductInCartDTO>(isUpdate);
            return productInCartDTO;

        }

        public async Task<bool> ClaerCart(int userId)
        {
            return await _ProductInCartDL.ClearCart(userId);
        }

        //public async Task<ProductInCartDTO> ClaerCart (ProductInCartDTO bag)
        //{
        //    try
        //    {
        //        await _ProductInCartDL.ClaerCartAsync();
        //        return new ProductInCartDTO();
        //    }
        //    catch (Exception ex) { return; }
        //}
    }
}
