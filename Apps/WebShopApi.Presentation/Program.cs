#if ApiConventions
using Microsoft.AspNetCore.Mvc;
[assembly: ApiConventionType(typeof(DefaultApiConventions))]
#endif
//Test
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebshopApi.Domain.Interfaces;
using WebshopApi.Domain.IServices;
using WebshopApi.Domain.Services;
using WebshopApi.Infrastructure.Data;
using WebshopApi.Infrastructure.Repositories;
using WebshopApi.REST.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICustomerRepository, EfCustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderLineRepository, EfOrderLineRepository>();
builder.Services.AddScoped<IOrderLineService, OrderLineService>();
builder.Services.AddScoped<IPriceTypeRepository, EfPriceTypeRepository>();
builder.Services.AddScoped<IPriceTypeService, PriceTypeService>();
builder.Services.AddScoped<IStoreRepository, EfStoreRepository>();
builder.Services.AddScoped<IStoreService, StoreService>();

// Add services to the container.
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
.Build();

var connectionString = config.GetConnectionString("DefaultMySQLConnection");
builder.Services.AddDbContextFactory<MyDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IgnoreNullValues = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000", "http://localhost:3001")
                           .AllowAnyMethod()
                           .AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply CORS policy
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
