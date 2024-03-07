using System.Text.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Models;
using System.Text.Json.Serialization;

namespace WebshopApi.REST.DTO.Receiving
{
    public class GetProductsDTO
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string NutriScore { get; set; }
        [JsonIgnore]
        public string? Description { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; }
        [JsonIgnore]
        public int PriceTypeId { get; set; }


        public int CategoryId { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public GetPriceTypeDTO PriceType { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public CategoryDTO Category { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ICollection<OrderLineDTO> OrderLines { get; set; }
        //[JsonIgnore]
        //public Supermarket Supermarket { get; set; }
    }
}
