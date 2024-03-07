using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Models;

namespace WebshopApi.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsByCatId(int catId);
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int productId);
    }
}
