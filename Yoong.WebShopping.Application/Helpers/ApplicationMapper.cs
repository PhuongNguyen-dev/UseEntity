using AutoMapper;
using UseEntity.Entities;
using UseEntity.Models;
using Yoong.WebShopping.Application.Models;

namespace UseEntity.Helpers
{
    public class ApplicationMapper : Profile 
    {
        public ApplicationMapper()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Cart, CartModel>().ReverseMap();
        }
    }
}
