using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace WebshopApi.Domain.Models
{
    public class Order
    {

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public double TotalPrice { get; set; }
        public bool IsPaid { get; set; }
        public bool IsActive { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public Customer Customer { get; set; }
        public Store Store { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
