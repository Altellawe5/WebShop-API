using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
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
    public class EfPriceTypeRepository : IPriceTypeRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public EfPriceTypeRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PriceType> GetByIdAsync(int id)
        {
            var priceType = await _context.PriceTypes.FindAsync(id);
            return _mapper.Map<PriceType>(priceType);
        }

        public async Task<IEnumerable<PriceType>> GetAllAsync()
        {
            var priceTypes = await _context.PriceTypes.ToListAsync();
            return _mapper.Map<List<PriceType>>(priceTypes);
        }

        public async Task<PriceType> AddAsync(PriceType priceType)
        {
            PriceTypeDbDTO priceTypeDbDTO = _mapper.Map<PriceTypeDbDTO>(priceType);
            // we are using Add of dbset to insert an entry
            _context.PriceTypes.Add(priceTypeDbDTO);
            await _context.SaveChangesAsync();
            return priceType;
        }

        public async Task UpdateAsync(PriceType priceType)
        {
            var priceTypeWithUpdates = _mapper.Map<PriceTypeDbDTO>(priceType);

            var priceTypeFromDatabase = await _context.PriceTypes.Where(c => c.Id == priceType.Id).FirstOrDefaultAsync();
            priceTypeFromDatabase.Products = priceTypeWithUpdates.Products;
            priceTypeFromDatabase.Type = priceTypeWithUpdates.Type;

            _context.Entry(priceTypeFromDatabase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int priceTypeId)
        {
            // we are using findasync of dbset to find entries
            var priceTypeToDelete = await _context.PriceTypes.FindAsync(priceTypeId);
            // we are using Remove method of dbset to delete entry
            if (priceTypeToDelete != null)
                _context.PriceTypes.Remove(priceTypeToDelete);
            await _context.SaveChangesAsync();
        }

    }

}
