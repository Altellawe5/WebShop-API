using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using WebshopApi.Domain.Interfaces;
using WebshopApi.Domain.IServices;
using WebshopApi.Domain.Models;
using WebshopApi.Domain.Services;
using WebshopApi.Infrastructure.Data;
using WebshopApi.REST.DTO.Receiving;
using WebshopApi.REST.DTO.Sending;

namespace WebShopApi.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;

        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetProductsDTO>>> GetProducts()
        {
            var products = await _productService.GetAllAsync();
            var mappedProducts =  _mapper.Map<IEnumerable<GetProductsDTO>>(products);

            return Ok(mappedProducts);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetProductsDTO>> GetProducts(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var mappedProduct = _mapper.Map<GetProductsDTO>(product);

            return Ok(mappedProduct);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetProductsDTO>>> GetProductsByName(string name)
        {
            var products = await _productService.GetProductsByName(name);
            var mappedProducts = _mapper.Map<IEnumerable<GetProductsDTO>>(products);

            return Ok(mappedProducts);
        }







        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Product>> PostProducts([FromBody] ProductDTO product)
        {
            var newProduct = await _productService.AddAsync(_mapper.Map<Product>(product));
            return CreatedAtAction(nameof(GetProducts), new { product.Id }, product);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutProducts(int productId, [FromBody] ProductDTO product)
        {
            if (productId != product.Id)
            {
                return BadRequest();
            }

            await _productService.UpdateAsync(_mapper.Map<Product>(product));
            return NoContent();
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProducts(int productId)
        {
            var productToDelete = await _productService.GetByIdAsync(productId);
            // We will check if the given id is present in database or not
            if (productToDelete == null)
                return NotFound();
            await _productService.DeleteAsync(productToDelete.Id);
            return NoContent();
        }

        private bool ProductExists(int id)
        {
            var product = _productService.GetByIdAsync(id);

            if (product == null) return false;
            else return true;
        }
    }
}
