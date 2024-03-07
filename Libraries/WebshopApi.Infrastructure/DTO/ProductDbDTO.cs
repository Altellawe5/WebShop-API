using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebshopApi.Domain.Models;

namespace WebshopApi.Infrastructure.DTO
{
    public class ProductDbDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string NutriScore { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int PriceTypeId { get; set; }
        public int CategoryId { get; set; }

        public PriceTypeDbDTO PriceType { get; set; }

        public CategoryDbDTO Category { get; set; }

        public ICollection<OrderLineDbDTO> OrderLines { get; set; }
        public Supermarket Supermarket { get; set; }
    }
}
