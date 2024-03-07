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
    public class OrderLineDbDTO
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public ProductDbDTO Product { get; set; }

        public OrderDbDTO Order { get; set; }

    }
}
