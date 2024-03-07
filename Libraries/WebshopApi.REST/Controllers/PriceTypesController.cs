using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebshopApi.Domain.Interfaces;
using WebshopApi.Domain.IServices;
using WebshopApi.Domain.Models;
using WebshopApi.Domain.Services;
using WebshopApi.Infrastructure.Data;
using WebshopApi.REST.DTO.Sending;

namespace WebShopApi.REST.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class PriceTypesController : ControllerBase
    {
        private readonly IPriceTypeService _priceTypeService;
        private readonly IMapper _mapper;

        public PriceTypesController(IPriceTypeService priceTypeService, IMapper mapper)
        {
            _mapper = mapper;
            _priceTypeService = priceTypeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PriceTypeDTO>>> GetPriceTypes()
        {
            return Ok(await _priceTypeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PriceTypeDTO>> GetPriceTypes(int id)
        {

            return Ok(await _priceTypeService.GetByIdAsync(id));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutPriceTypes(int PriceTypeId, [FromBody] PriceTypeDTO priceType)
        {
            // Check if the given id is present database or not; if not then we will return bad request
            if (PriceTypeId != priceType.Id)
            {
                return BadRequest();
            }
            await _priceTypeService.UpdateAsync(_mapper.Map<PriceType>(priceType));
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<PriceType>> PostPriceTypes([FromBody] PriceTypeDTO priceType)
        {
            var newPriceType = await _priceTypeService.AddAsync(_mapper.Map<PriceType>(priceType));
            return CreatedAtAction(nameof(GetPriceTypes), new { newPriceType.Id }, newPriceType);
        }

        [HttpDelete("{priceTypeId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletePriceTypes(int priceTypeId)
        {
            var priceTypeToDelete = await _priceTypeService.GetByIdAsync(priceTypeId);
            // We will check if the given id is present in database or not
            if (priceTypeToDelete == null)
                return NotFound();
            await _priceTypeService.DeleteAsync(priceTypeToDelete.Id);
            return NoContent();
        }

        private bool PriceTypeExists(int id)
        {
            var priceType = _priceTypeService.GetByIdAsync(id);

            if (priceType == null) return false;
            else return true;
        }
    }
}
