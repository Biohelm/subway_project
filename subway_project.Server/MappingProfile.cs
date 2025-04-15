using AutoMapper;
using subway_project.Server.Models;
using subway_shared.DTOs.OrderDTOs;
using subway_shared.DTOs.ProductDTOs;
using subway_shared.DTOs.SubDTOs;
using subway_shared.DTOs.ToppingDTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductPostDTO, Product>();
        CreateMap<OrderDTO, Order>();
        CreateMap<ToppingDTO,SubIngredients>();
        CreateMap<SubDTO, Sub>();
    }
}
