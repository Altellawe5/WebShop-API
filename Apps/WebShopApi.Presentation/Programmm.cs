//using Microsoft.AspNet.Identity;
//using Microsoft.AspNetCore.DataProtection.Repositories;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Internal;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Options;
//using WebshopApi.Domain.Interfaces;
//using WebshopApi.Domain.IServices;
//using WebshopApi.Domain.Models;
//using WebshopApi.Domain.Services;
//using WebshopApi.Infrastructure.Config;
//using WebshopApi.Infrastructure.Data;
//using WebshopApi.Infrastructure.Mapping;
//using WebshopApi.Infrastructure.Repositories;
//


//namespace WebshopApi.Presentation
//{
//    public class Programmm
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.
//            var config = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//            .Build();

//            //builder.Services.AddAutoMapper(typeof(MappingConfig));
//            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
//            builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
//            builder.Services.AddScoped<ICategoryService, CategoryService>();
//            builder.Services.AddScoped<ICustomerRepository, EfCustomerRepository>();
//            builder.Services.AddScoped<ICustomerService, CustomerService>();
//            builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();
//            builder.Services.AddScoped<IOrderService, OrderService>();
//            builder.Services.AddScoped<IProductRepository, EfProductRepository>();
//            builder.Services.AddScoped<IProductService, ProductService>();
//            builder.Services.AddScoped<IOrderLineRepository, EfOrderLineRepository>();
//            builder.Services.AddScoped<IOrderLineService, OrderLineService>();
//            builder.Services.AddScoped<IPriceTypeRepository, EfPriceTypeRepository>();
//            builder.Services.AddScoped<IPriceTypeService, PriceTypeService>();
//            builder.Services.AddScoped<IStoreRepository, EfStoreRepository>();
//            builder.Services.AddScoped<IStoreService, StoreService>();




//            builder.Services.AddControllers();

//            var connectionString = config.GetConnectionString("DefaultMySQLConnection");
//            builder.Services.AddDbContextFactory<MyDbContext>(options =>
//                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();


//            app.MapControllers();

//            app.Run();
//        }
//    }
//}
