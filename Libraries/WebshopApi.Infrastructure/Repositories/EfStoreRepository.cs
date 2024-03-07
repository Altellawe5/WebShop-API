using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Interfaces;
using WebshopApi.Domain.Models;
using WebshopApi.Infrastructure.Data;
using WebshopApi.Infrastructure.DTO;

namespace WebshopApi.Infrastructure.Repositories
{
    public class EfStoreRepository : IStoreRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public EfStoreRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Store> GetByIdAsync(int id)
        {
            var store = await _context.Stores.FindAsync(id);
            return _mapper.Map<Store>(store);
        }

        public async Task<IEnumerable<Store>> GetAllAsync()
        {
            var stores = await _context.Stores.ToListAsync();
            return _mapper.Map<List<Store>>(stores);
        }

        public async Task<Store> AddAsync(Store store)
        {
            StoreDbDTO storeDbDTO = _mapper.Map<StoreDbDTO>(store);
            // we are using Add of dbset to insert an entry
            _context.Stores.Add(storeDbDTO);
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task UpdateAsync(Store store)
        {
            var storeWithUpdates = _mapper.Map<StoreDbDTO>(store);

            var storeFromDatabase = await _context.Stores.Where(c => c.Id == store.Id).FirstOrDefaultAsync();
            storeFromDatabase.Name = storeWithUpdates.Name;
           
            _context.Entry(storeFromDatabase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int storeId)
        {
            // we are using findasync of dbset to find entries
            var storeToDelete = await _context.Stores.FindAsync(storeId);
            // we are using Remove method of dbset to delete entry
            if (storeToDelete != null)
                _context.Stores.Remove(storeToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
