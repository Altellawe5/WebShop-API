using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebshopApi.Infrastructure.DTO;

namespace WebshopApi.REST.DTO.Sending
{
    public class OrderDTO
    {
        [Required]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public double TotalPrice { get; set; }
        public bool IsPaid { get; set; }
        public bool IsActive { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public CustomerDTO Customer { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public StoreDTO Store { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ICollection<OrderLineDTO> OrderLines { get; set; }
    }
}
