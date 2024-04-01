using AutoMapper;
using DAL.Models;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{ 
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap <ProductInCart, ProductInCartDTO > ();
            CreateMap < User, UserDTO > ();
            CreateMap<User, UserLoginDTO>();
            CreateMap < Category, CategoryDTO > ();
            CreateMap <Contct, ContctDTO > ();
            CreateMap <Order, OrderDTO > ();
            CreateMap <OrdersProduct, OrdersProductDTO > ();
            CreateMap <Product, ProductDTO > ();
            CreateMap <Status, StatusDTO > ();


            CreateMap<ProductInCartDTO, ProductInCart>();
            CreateMap<UserDTO, User>();
            CreateMap<UserLoginDTO, User>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<ContctDTO, Contct>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrdersProductDTO, OrdersProduct>();
            CreateMap<ProductDTO, Product>();
            CreateMap<StatusDTO, Status>();

        }

    }
}
