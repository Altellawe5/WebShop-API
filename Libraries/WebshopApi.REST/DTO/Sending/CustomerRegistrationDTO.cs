using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopApi.REST.DTO.Sending
{
    public class CustomerRegistrationDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public bool IsActive { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
    }
}
