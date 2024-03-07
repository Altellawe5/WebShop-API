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
    public class OrderDbDTO
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public double TotalPrice { get; set; }
        public bool IsPaid { get; set; }
        public bool IsActive { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }

        public CustomerDbDTO Customer { get; set; }

        public StoreDbDTO Store { get; set; }

        public ICollection<OrderLineDbDTO> OrderLines { get; set; }
    }
}
