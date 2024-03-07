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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> AddAsync(Order order)
        {
            return await _orderRepository.AddAsync(order);
        }

        public async Task UpdateAsync(Order order)
        {
            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteAsync(int orderId)
        {
            await _orderRepository.DeleteAsync(orderId);
        }
    }
}
