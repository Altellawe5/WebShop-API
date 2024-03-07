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
    public class EfOrderLineRepository : IOrderLineRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public EfOrderLineRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<OrderLine> GetByIdAsync(int id)
        {
            var orderline = await _context.OrderLines.FindAsync(id);
            return _mapper.Map<OrderLine>(orderline);
        }

        public async Task<IEnumerable<OrderLine>> GetAllAsync()
        {
            var orderlines = await _context.OrderLines.ToListAsync();
            return _mapper.Map<List<OrderLine>>(orderlines);
        }

        public async Task<OrderLine> AddAsync(OrderLine orderLine)
        {
            OrderLineDbDTO orderLineDbDTO = _mapper.Map<OrderLineDbDTO>(orderLine);
            // we are using Add of dbset to insert an entry
            _context.OrderLines.Add(orderLineDbDTO);
            await _context.SaveChangesAsync();
            return orderLine;
        }

        public async Task UpdateAsync(OrderLine orderLine)
        {
            var orderLineWithUpdates = _mapper.Map<OrderLineDbDTO>(orderLine);

            var orderLineFromDatabase = await _context.OrderLines.Where(c => c.Id == orderLine.Id).FirstOrDefaultAsync();
       
            orderLineFromDatabase.OrderId = orderLineWithUpdates.OrderId;
            orderLineFromDatabase.ProductId = orderLineWithUpdates.ProductId;
            orderLineFromDatabase.Quantity = orderLineWithUpdates.Quantity;
            orderLineFromDatabase.Price = orderLineWithUpdates.Price;
            orderLineFromDatabase.IsActive = orderLineWithUpdates.IsActive;
            _context.Entry(orderLineFromDatabase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int orderLineId)
        {
            // we are using findasync of dbset to find entries
            var orderLineToDelete = await _context.OrderLines.FindAsync(orderLineId);
            // we are using Remove method of dbset to delete entry
            if (orderLineToDelete != null)
                _context.OrderLines.Remove(orderLineToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
