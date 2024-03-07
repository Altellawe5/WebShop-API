using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebshopApi.Domain.Models;
using WebshopApi.Infrastructure.DTO;

namespace WebshopApi.REST.DTO.Sending
{
    public class ProductDTO
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string NutriScore { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int PriceTypeId { get; set; }
        public int CategoryId { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public PriceTypeDTO PriceType { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public CategoryDTO Category { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ICollection<OrderLineDTO> OrderLines { get; set; }
        public Supermarket Supermarket { get; set; }
    }
}
