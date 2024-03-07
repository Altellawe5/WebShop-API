using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Models;

namespace WebshopApi.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int custId);
        Task<Customer> GetUserByEmail(string email);
     



    }
}
