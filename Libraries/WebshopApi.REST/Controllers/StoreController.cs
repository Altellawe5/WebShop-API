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
using WebshopApi.REST.DTO.Sending;

namespace WebShopApi.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public StoreController(IStoreService storeService, IMapper mapper)
        {
            _mapper = mapper;
            _storeService = storeService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StoreDTO>>> GetStores()
        {
            return Ok(await _storeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StoreDTO>> GetStores(int id)
        {
            return Ok(await _storeService.GetByIdAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<StoreDTO>> PostStores([FromBody] StoreDTO store)
        {
            var newStore = await _storeService.AddAsync(_mapper.Map<Store>(store));
            return CreatedAtAction(nameof(GetStores), new { store.Id }, store);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutStores(int storeId, [FromBody] StoreDTO store)
        {
            if (storeId != store.Id)
            {
                return BadRequest();
            }

            await _storeService.UpdateAsync(_mapper.Map<Store>(store));
            return NoContent();
        }

        [HttpDelete("{storeId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteStores(int storeId)
        {
            var storeToDelete = await _storeService.GetByIdAsync(storeId);
            // We will check if the given id is present in database or not
            if (storeToDelete == null)
                return NotFound();
            await _storeService.DeleteAsync(storeToDelete.Id);
            return NoContent();
        }

        private bool StoreExists(int id)
        {
            var store = _storeService.GetByIdAsync(id);

            if (store == null) return false;
            else return true;
        }
    }
}
