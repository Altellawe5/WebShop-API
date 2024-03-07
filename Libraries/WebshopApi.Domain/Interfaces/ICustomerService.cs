using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Models;

namespace WebshopApi.Domain.IServices
{
    public interface ICustomerService
    {
        Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int custId);
        Task<Customer> GetUserByEmail(string email);
        Task<bool> RegisterAsync(string email, string password);
        Task<Customer> LoginAsync(string email, string password);
    }
}
