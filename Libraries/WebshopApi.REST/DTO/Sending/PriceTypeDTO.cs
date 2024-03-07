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
    public class PriceTypeDTO
    {
        [Required]
        public int Id { get; set; }
        public string Type { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ICollection<ProductDTO> Products { get; set; }
    }
}
