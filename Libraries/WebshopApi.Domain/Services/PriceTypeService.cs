using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Interfaces;
using WebshopApi.Domain.Models;

namespace WebshopApi.Domain.Services
{
    public class PriceTypeService : IPriceTypeService
    {
        private readonly IPriceTypeRepository _priceTypeRepository;

        public PriceTypeService(IPriceTypeRepository priceTypeRepository)
        {
            _priceTypeRepository = priceTypeRepository;
        }

        public async Task<PriceType> GetByIdAsync(int id)
        {
            return await _priceTypeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PriceType>> GetAllAsync()
        {
            return await _priceTypeRepository.GetAllAsync();
        }

        public async Task<PriceType> AddAsync(PriceType priceType)
        {
            return await _priceTypeRepository.AddAsync(priceType);
        }

        public async Task UpdateAsync(PriceType priceType)
        {
            await _priceTypeRepository.UpdateAsync(priceType);
        }

        public async Task DeleteAsync(int priceTypeId)
        {
            await _priceTypeRepository.DeleteAsync(priceTypeId);
        }
    }
}
