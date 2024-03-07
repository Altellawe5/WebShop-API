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
    public class CustomerDTO
    {

        [Required]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public ICollection<OrderDTO> Orders { get; set; }
    }
}
