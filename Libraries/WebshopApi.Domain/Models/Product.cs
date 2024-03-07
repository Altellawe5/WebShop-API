using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopApi.Domain.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string NutriScore { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int PriceTypeId { get; set; }
        public int CategoryId { get; set; }
        public PriceType PriceType { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }

    }
}
