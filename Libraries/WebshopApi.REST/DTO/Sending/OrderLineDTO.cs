using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebshopApi.Infrastructure.DTO;

namespace WebshopApi.REST.DTO.Sending
{
    public class OrderLineDTO
    {
        [Required]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ProductDTO Product { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public OrderDTO Order { get; set; }
    }
}
