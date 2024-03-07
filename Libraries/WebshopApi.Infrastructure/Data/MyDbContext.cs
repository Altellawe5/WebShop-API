using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebshopApi.Infrastructure.DTO;

namespace WebshopApi.Infrastructure.Data
{
    public class MyDbContext : DbContext
    {
        //private readonly IConfiguration _configuration;


        public DbSet<CategoryDbDTO> Categories { get; set; }
        public DbSet<CustomerDbDTO> Customers { get; set; }
        public DbSet<OrderDbDTO> Orders { get; set; }
        public DbSet<OrderLineDbDTO> OrderLines { get; set; }
        public DbSet<PriceTypeDbDTO> PriceTypes { get; set; }
        public DbSet<ProductDbDTO> Products { get; set; }
        public DbSet<StoreDbDTO> Stores { get; set; }






        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
           

            //// To ensure that database is created through dbcontext
            //Database.EnsureCreated();
        }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }

      



    }
}
