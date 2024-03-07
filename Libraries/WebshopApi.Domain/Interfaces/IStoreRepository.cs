using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Models;

namespace WebshopApi.Domain.Interfaces
{
    public interface IStoreRepository
    {
        Task<Store> GetByIdAsync(int id);
        Task<IEnumerable<Store>> GetAllAsync();
        Task<Store> AddAsync(Store store);
        Task UpdateAsync(Store store);
        Task DeleteAsync(int storeId);
    }
}
