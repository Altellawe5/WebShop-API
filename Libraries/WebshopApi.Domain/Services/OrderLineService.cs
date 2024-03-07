using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Interfaces;
using WebshopApi.Domain.Models;

namespace WebshopApi.Domain.Services
{
    public class OrderLineService : IOrderLineService
    {
        private readonly IOrderLineRepository _orderLineRepository;

        public OrderLineService(IOrderLineRepository orderLineRepository)
        {
            _orderLineRepository = orderLineRepository;
        }

        public async Task<OrderLine> GetByIdAsync(int id)
        {
            return await _orderLineRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<OrderLine>> GetAllAsync()
        {
            return await _orderLineRepository.GetAllAsync();
        }

        public async Task<OrderLine> AddAsync(OrderLine orderLine)
        {
            return await _orderLineRepository.AddAsync(orderLine);
        }

        public async Task UpdateAsync(OrderLine orderLine)
        {
            await _orderLineRepository.UpdateAsync(orderLine);
        }

        public async Task DeleteAsync(int orderLineId)
        {
            await _orderLineRepository.DeleteAsync(orderLineId);
        }
    }
}
