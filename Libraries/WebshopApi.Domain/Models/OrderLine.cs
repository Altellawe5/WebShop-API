using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopApi.Domain.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
