using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Models;
using WebshopApi.Infrastructure.DTO;

namespace WebshopApi.Infrastructure.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
       
            CreateMap<CategoryDbDTO, Category>().ReverseMap();


            CreateMap<CustomerDbDTO, Customer>().ReverseMap();



            CreateMap<OrderDbDTO, Order>().ReverseMap();


            CreateMap<OrderLineDbDTO, OrderLine>().ReverseMap();

 
            CreateMap<PriceTypeDbDTO, PriceType>().ReverseMap();


                //.ForMember(dest => dest.Price, opt => opt.MapFrom(src => (decimal)src.Price))
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                //.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
                //.ForMember(dest => dest.PriceTypeId, opt => opt.MapFrom(src => src.PriceType.Id));
            CreateMap<ProductDbDTO, Product>().ReverseMap();
            //.ForMember(dest => dest.Price, opt => opt.MapFrom(src => (float)src.Price))
            //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            //.ForMember(dest => dest.Category, opt => opt.Ignore())
            //.ForMember(dest => dest.PriceType, opt => opt.Ignore());


            CreateMap<StoreDbDTO, Store>().ReverseMap();
        }
    }
}
