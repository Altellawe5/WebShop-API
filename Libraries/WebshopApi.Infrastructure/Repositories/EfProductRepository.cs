using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Interfaces;
using WebshopApi.Domain.Models;
using WebshopApi.Infrastructure.Data;
using WebshopApi.Infrastructure.DTO;

namespace WebshopApi.Infrastructure.Repositories
{
    public class EfProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public EfProductRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products.Include(p => p.PriceType).FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<Product>(product);
        }


        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            var products = await _context.Products.Include(p => p.PriceType)
              .Where(p => p.Name.ToLower().Contains(name.ToLower()) || p.Brand.ToLower().Contains(name.ToLower()))
              .ToListAsync();

            return _mapper.Map<List<Product>>(products);
        }

        public async Task<IEnumerable<Product>> GetProductsByCatId(int catId)
        {
            var products = await _context.Products.Include(p => p.PriceType).Where(p => p.CategoryId == catId).ToListAsync();
            return _mapper.Map<List<Product>>(products);
        }


        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Products.Include(p => p.PriceType).ToListAsync();
            return _mapper.Map<List<Product>>(products);
        }

        public async Task<Product> AddAsync(Product product)
        {
            ProductDbDTO productDbDTO = _mapper.Map<ProductDbDTO>(product);
            // we are using Add of dbset to insert an entry
            _context.Products.Add(productDbDTO);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            var productWithUpdates = _mapper.Map<ProductDbDTO>(product);

            var productFromDatabase = await _context.Products.Where(c => c.Id == product.Id).FirstOrDefaultAsync();
            productFromDatabase.IsActive = productWithUpdates.IsActive;
            productFromDatabase.Name = productWithUpdates.Name;
            productFromDatabase.Brand = productWithUpdates.Brand;
            productFromDatabase.Price = productWithUpdates.Price;
            productFromDatabase.PriceTypeId = productWithUpdates.PriceTypeId;
            productFromDatabase.Supermarket = productWithUpdates.Supermarket;
            productFromDatabase.CategoryId = productWithUpdates.CategoryId;
            productFromDatabase.NutriScore = productWithUpdates.NutriScore;
            productFromDatabase.Description = productWithUpdates.Description;

            _context.Entry(productFromDatabase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productId)
        {
            // we are using findasync of dbset to find entries
            var productToDelete = await _context.Products.FindAsync(productId);
            // we are using Remove method of dbset to delete entry
            if (productToDelete != null)
                _context.Products.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }

       
    }
}
