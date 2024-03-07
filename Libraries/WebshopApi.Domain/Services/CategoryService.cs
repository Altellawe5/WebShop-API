using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Interfaces;
using WebshopApi.Domain.IServices;
using WebshopApi.Domain.Models;

namespace WebshopApi.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> AddAsync(Category category)
        {
            return await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteAsync(int categoryId)
        {
            await _categoryRepository.DeleteAsync(categoryId);
        }

       
    }
}
