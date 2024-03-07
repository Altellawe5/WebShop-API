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
    public class EfOrderRepository : IOrderRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public EfOrderRepository(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //


        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return _mapper.Map<Order>(order);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = await _context.Orders.ToListAsync();
            return _mapper.Map<List<Order>>(orders);
        }

        public async Task<Order> AddAsync(Order order)
        {
            OrderDbDTO orderDbDTO = _mapper.Map<OrderDbDTO>(order);
            // we are using Add of dbset to insert an entry
            _context.Orders.Add(orderDbDTO);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task UpdateAsync(Order order)
        {
            var orderWithUpdates = _mapper.Map<OrderDbDTO>(order);

            var orderFromDatabase = await _context.Orders.Where(c => c.Id == order.Id).FirstOrDefaultAsync();
            orderFromDatabase.IsActive = orderWithUpdates.IsActive;
            orderFromDatabase.TotalPrice = orderWithUpdates.TotalPrice;
            orderFromDatabase.IsPaid = orderWithUpdates.IsPaid;
            orderFromDatabase.StoreId = orderWithUpdates.StoreId;
            orderFromDatabase.CustomerId = orderWithUpdates.CustomerId;
            //orderFromDatabase.Created = orderWithUpdates.Created;
    
            _context.Entry(orderFromDatabase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int orderId)
        {
            // we are using findasync of dbset to find entries
            var orderToDelete = await _context.OrderLines.FindAsync(orderId);
            // we are using Remove method of dbset to delete entry
            if (orderToDelete != null)
                _context.OrderLines.Remove(orderToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
