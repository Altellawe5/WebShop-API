using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WebshopApi.Domain.Interfaces;
using WebshopApi.Domain.IServices;
using WebshopApi.Domain.Models;
using WebshopApi.Domain.Services;
using WebshopApi.REST.DTO.Receiving;
using WebshopApi.REST.DTO.Sending;

namespace WebShopApi.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IProductService productService , IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CategoryDTO>> GetCategories(int id)
        {
            return Ok(await _categoryService.GetByIdAsync(id));
        }

        [HttpGet("{categoryId}/Products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductDTO>> GetProductsByCategory(int categoryId)
        {
            var products = await _productService.GetProductsByCatId(categoryId);
            var mappedProducts = _mapper.Map<IEnumerable<GetProductsDTO>>(products);

            return Ok(mappedProducts);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CategoryDTO>> PostCategories([FromBody] CategoryDTO category)
        {
            var newCategory = await _categoryService.AddAsync(_mapper.Map<Category>(category));
            return CreatedAtAction(nameof(GetCategories), new { newCategory.Id }, newCategory);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutCategories(int CatId, [FromBody] CategoryDTO category)
        {
            // Check if the given id is present database or not; if not then we will return bad request
            if (CatId != category.Id)
            {
                return BadRequest();
            }
            await _categoryService.UpdateAsync(_mapper.Map<Category>(category));
            return NoContent();
        }

        [HttpDelete("{CatId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCategories(int CatId)
        {
            var categoryToDelete = await _categoryService.GetByIdAsync(CatId);
            // We will check if the given id is present in database or not
            if (categoryToDelete == null)
                return NotFound();
            await _categoryService.DeleteAsync(categoryToDelete.Id);
            return NoContent();
        }
    }
}
