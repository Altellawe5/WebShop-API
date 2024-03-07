using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Models;
using WebshopApi.Infrastructure.DTO;
using WebshopApi.REST.DTO.Receiving;
using WebshopApi.REST.DTO.Sending;

namespace WebshopApi.REST.Mapping
{
    public class MappingConfig : Infrastructure.Mapping.MappingConfig
    {
        public MappingConfig() : base()
        {
           
            CreateMap<CategoryDTO, Category>().ReverseMap();

      
            CreateMap<CustomerDTO, Customer>().ReverseMap();

        

            CreateMap<OrderDTO, Order>().ReverseMap();

     
            CreateMap<OrderLineDTO, OrderLine>().ReverseMap();

  
            CreateMap<PriceTypeDTO, PriceType>().ReverseMap();

       
            //.ForMember(dest => dest.Price, opt => opt.MapFrom(src => (decimal)src.Price))
            //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            //.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
            //.ForMember(dest => dest.PriceTypeId, opt => opt.MapFrom(src => src.PriceType.Id));
            CreateMap<ProductDTO, Product>().ReverseMap();

            CreateMap<PriceType, GetPriceTypeDTO>().ReverseMap();
            CreateMap<Product, GetProductsDTO>()
             .ForMember(dest => dest.PriceType, opt => opt.MapFrom(src => src.PriceType)).ReverseMap();
    
            //.ForMember(dest => dest.Price, opt => opt.MapFrom(src => (float)src.Price))
            //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            //.ForMember(dest => dest.Category, opt => opt.Ignore())
            //.ForMember(dest => dest.PriceType, opt => opt.Ignore());


            CreateMap<StoreDTO, Store>().ReverseMap();
        }
    }
}
