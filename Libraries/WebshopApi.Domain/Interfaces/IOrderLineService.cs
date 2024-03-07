using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Models;

namespace WebshopApi.Domain.Interfaces
{
    public interface IOrderLineService
    {
        Task<OrderLine> GetByIdAsync(int id);
        Task<IEnumerable<OrderLine>> GetAllAsync();
        Task<OrderLine> AddAsync(OrderLine orderLine);
        Task UpdateAsync(OrderLine orderLine);
        Task DeleteAsync(int orderLineId);
    }
}
