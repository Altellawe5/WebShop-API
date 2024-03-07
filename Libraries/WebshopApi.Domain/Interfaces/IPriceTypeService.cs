using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Models;

namespace WebshopApi.Domain.Interfaces
{
    public interface IPriceTypeService
    {
        Task<PriceType> GetByIdAsync(int id);
        Task<IEnumerable<PriceType>> GetAllAsync();
        Task<PriceType> AddAsync(PriceType priceType);
        Task UpdateAsync(PriceType priceType);
        Task DeleteAsync(int priceTypeId);
    }
}
