using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Models;

namespace WebshopApi.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int catId);

    }
}
