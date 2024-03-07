using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopApi.Domain.Models
{
    public class PriceType
    {

        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
