using SaleServer.DTO;
using SaleServer.Models;
using AutoMapper;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SaleServer
{
    public class Mapper : Profile
    {
        
            public Mapper()
            {
                
                CreateMap<Order, OrderDTO>().ReverseMap();
                CreateMap<Gifts, GiftDTO>().ReverseMap();
                CreateMap<GiftDTO, Gifts > ().ReverseMap();
                CreateMap<CartDTO, Cart>().ReverseMap();
                CreateMap<User, UserDTO>().ReverseMap();

            }


    }
}
