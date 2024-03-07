using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using WebshopApi.Domain.IServices;
using WebshopApi.Domain.Models;
using WebshopApi.REST.DTO.Sending;

namespace WebShopApi.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            _orderService = orderService;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            return Ok(await _orderService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderDTO>> GetOrders(int id)
        {
            return Ok(await _orderService.GetByIdAsync(id));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<OrderDTO>> PostOrders([FromBody] OrderDTO order)
        {
            var newOrder = await _orderService.AddAsync(_mapper.Map<Order>(order));
            return CreatedAtAction(nameof(GetOrders), new { newOrder.Id }, newOrder);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> PutOrders(int orderId, [FromBody] OrderDTO order)
        {
            // Check if the given id is present database or not; if not then we will return bad request
            if (orderId != order.Id)
            {
                return BadRequest();
            }
            await _orderService.UpdateAsync(_mapper.Map<Order>(order));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            var orderToDelete = await _orderService.GetByIdAsync(id);
            // We will check if the given id is present in database or not
            if (orderToDelete == null)
                return NotFound();
            await _orderService.DeleteAsync(orderToDelete.Id);
            return NoContent();
        }
    }
}
