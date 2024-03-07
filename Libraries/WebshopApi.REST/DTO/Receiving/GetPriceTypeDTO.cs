using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopApi.REST.DTO.Receiving
{
    public class GetPriceTypeDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
