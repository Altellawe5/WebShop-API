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
    public class EfCustomerRepository : ICustomerRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public EfCustomerRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return _mapper.Map<Customer>(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return _mapper.Map<List<Customer>>(customers);
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            CustomerDbDTO customerDbDTO = _mapper.Map<CustomerDbDTO>(customer);
            // we are using Add of dbset to insert an entry
            _context.Customers.Add(customerDbDTO);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task UpdateAsync(Customer customer)
        {
            var customerWithUpdates = _mapper.Map<CustomerDbDTO>(customer);

            var customerFromDatabase = await _context.Customers.Where(c => c.Id == customer.Id).FirstOrDefaultAsync();
            customerFromDatabase.Email = customerWithUpdates.Email;
            customerFromDatabase.Surname = customerWithUpdates.Surname;
            customerFromDatabase.Orders = customerWithUpdates.Orders;
            customerFromDatabase.Firstname = customerWithUpdates.Firstname;
            customerFromDatabase.Password = customerWithUpdates.Password;
            _context.Entry(customerFromDatabase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int customerId)
        {
            // we are using findasync of dbset to find entries
            var customerToDelete = await _context.Customers.FindAsync(customerId);
            // we are using Remove method of dbset to delete entry
            if (customerToDelete != null)
                _context.Customers.Remove(customerToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetUserByEmail(string email)
        {
            var customer = await _context.Customers.FindAsync(email);
            return _mapper.Map<Customer>(customer);
        }

      


    }

}
