using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebshopApi.Infrastructure.DTO
{
    public class CustomerDbDTO
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }

        public ICollection<OrderDbDTO> Orders { get; set; }
    }
}
