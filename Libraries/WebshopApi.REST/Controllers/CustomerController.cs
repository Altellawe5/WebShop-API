using AutoMapper;
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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _mapper = mapper;
            _customerService = customerService;
      
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CustomerRegistrationDTO registrationDto)
        {
            //
            if (await _customerService.GetUserByEmail(registrationDto.Email) != null)
            {
                return BadRequest("User with the same email already exists.");
            }

            var user = new CustomerRegistrationDTO
            {
                Email = registrationDto.Email,
                Password = registrationDto.Password,
                RepeatPassword = registrationDto.Password,
                IsActive = true
            };

            await _customerService.AddAsync(_mapper.Map<Customer>(user));

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CustomerLoginDTO loginDto)
        {
            var user = await _customerService.GetUserByEmail(loginDto.Email);

            if (user == null)
            {
                return BadRequest("Invalid email or password.");
            }

            if (user.Password != loginDto.Password)
            {
                return BadRequest("Invalid email or password.");
            }

            // generate JWT token here and return it in the response
            return Ok();
        }
    }
}
