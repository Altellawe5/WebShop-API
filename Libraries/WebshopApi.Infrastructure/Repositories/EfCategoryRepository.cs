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
    public class EfCategoryRepository : ICategoryRepository
    {

        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public EfCategoryRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            return _mapper.Map<Category>(cat);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var cats = await _context.Categories.ToListAsync();
            return _mapper.Map<List<Category>>(cats);
        }

        public async Task<Category> AddAsync(Category category)
        {
            CategoryDbDTO categoryDbDTO = _mapper.Map<CategoryDbDTO>(category);
            // we are using Add of dbset to insert an entry
            _context.Categories.Add(categoryDbDTO);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task UpdateAsync(Category category)
        {

            var catWithUpdates = _mapper.Map<CategoryDbDTO>(category);

            var catFromDatabase = await _context.Categories.Where(c => c.Id == category.Id).FirstOrDefaultAsync();
            catFromDatabase.Products = catWithUpdates.Products;
            catFromDatabase.Name = catWithUpdates.Name;
            _context.Entry(catFromDatabase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int catId)
        {
            // we are using findasync of dbset to find entries
            var catToDelete = await _context.Categories.FindAsync(catId);
            // we are using Remove method of dbset to delete entry
            if (catToDelete != null)
                _context.Categories.Remove(catToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetByName(string name)
        {
            var cat = await _context.Categories.FindAsync(name);
            return _mapper.Map<Category>(cat);
        }


    }
}
