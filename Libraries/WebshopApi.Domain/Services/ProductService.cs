using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Interfaces;
using WebshopApi.Domain.Models;


namespace WebshopApi.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await _productRepository.GetProductsByName(name);
        }

        public async Task<IEnumerable<Product>> GetProductsByCatId(int id)
        {
            return await _productRepository.GetProductsByCatId(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> AddAsync(Product product)
        {
            return await _productRepository.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int productId)
        {
            await _productRepository.DeleteAsync(productId);
        }
    }
}
