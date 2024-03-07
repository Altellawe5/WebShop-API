using Microsoft.AspNet.Identity;
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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPasswordHasher _passwordHasher;

        public CustomerService(ICustomerRepository customerRepository, IPasswordHasher passwordHasher)
        {
            _customerRepository = customerRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            return await _customerRepository.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(int customerId)
        {
            await _customerRepository.DeleteAsync(customerId);
        }

        public async Task<Customer> GetUserByEmail(string email)
        {
           return await _customerRepository.GetUserByEmail(email);
        }

        public async Task<bool> RegisterAsync(string email, string password)
        {
            // Check if user with this email already exists
            var existingUser = await _customerRepository.GetUserByEmail(email);
            if (existingUser != null)
            {
                return false;
            }

            // Hash the password using bcrypt
            var hashedPassword = _passwordHasher.HashPassword(password);

            // Add user to the database
            Customer newCustomer = new Customer
            {
                Email = email,
                Password = hashedPassword
            };

            await _customerRepository.AddAsync(newCustomer);

            return true;
        }

        public async Task<Customer> LoginAsync(string email, string password)
        {
            // Get the user with the provided email
            var user = await _customerRepository.GetUserByEmail(email);

            // If no user found, return null
            if (user == null)
            {
                return null;
            }

            // Verify the provided password with the hashed password in the database
            var passwordMatch = _passwordHasher.VerifyHashedPassword(user.Password, password);

            if (passwordMatch == PasswordVerificationResult.Success)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }

}
