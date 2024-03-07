using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Interfaces;
using WebshopApi.Domain.Models;

namespace WebshopApi.Domain.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<Store> GetByIdAsync(int id)
        {
            return await _storeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Store>> GetAllAsync()
        {
            return await _storeRepository.GetAllAsync();
        }

        public async Task<Store> AddAsync(Store store)
        {
            return await _storeRepository.AddAsync(store);
        }

        public async Task UpdateAsync(Store store)
        {
            await _storeRepository.UpdateAsync(store);
        }

        public async Task DeleteAsync(int storeId)
        {
            await _storeRepository.DeleteAsync(storeId);
        }
    }
}
