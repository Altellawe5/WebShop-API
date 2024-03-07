using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebshopApi.REST.DTO.Sending
{
    public class StoreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[JsonProperty(a = NullValueHandling.Ignore)]
        //public ICollection<OrderDTO> Orders { get; set; }
    }
}
