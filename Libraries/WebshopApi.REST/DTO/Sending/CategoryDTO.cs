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
    public class CategoryDTO
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        //public ICollection<ProductDTO> Products { get; set; }
    }
}
