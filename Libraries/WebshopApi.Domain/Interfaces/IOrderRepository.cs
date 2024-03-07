using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Models;

namespace WebshopApi.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int orderId);

    }
}
