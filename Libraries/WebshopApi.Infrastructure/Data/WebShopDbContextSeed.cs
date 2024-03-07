using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopApi.Domain.Models;
using WebshopApi.Infrastructure.DTO;

namespace WebshopApi.Infrastructure.Data
{
    public class WebShopDbContextSeed
    {

        private readonly MyDbContext _dbContext;
        public WebShopDbContextSeed(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if(_dbContext.Categories.Any() || _dbContext.Products.Any() || _dbContext.PriceTypes.Any())
            {
                return;
            }

            var categories = new List<CategoryDbDTO>
                {
                    new CategoryDbDTO { Name = "Vegetables" },
                    new CategoryDbDTO { Name = "Fruit" },
                    new CategoryDbDTO { Name = "Dairy" },
                    new CategoryDbDTO { Name = "Bakery" },
                    new CategoryDbDTO { Name = "Meat & Poultry" },
                    new CategoryDbDTO { Name = "Seafood" },
                    new CategoryDbDTO { Name = "Snacks & Candy" },
                    new CategoryDbDTO { Name = "Beverages" },
                    new CategoryDbDTO { Name = "Frozen Foods" },
                    new CategoryDbDTO { Name = "Produce" },
                    new CategoryDbDTO { Name = "Dairy & Eggs" }
                };

            var priceTypes = new List<PriceTypeDbDTO>
                {
                    new PriceTypeDbDTO { Type = "Per Product" },
                    new PriceTypeDbDTO { Type = "Per KG" }
                };

            var products = new List<ProductDbDTO>
                {
                    new ProductDbDTO { Name = "Cucumber", Price = 1.61M, CategoryId = 1, PriceTypeId = 2 , Supermarket = Supermarket.Delhaize , IsActive = true },
                    new ProductDbDTO { Name = "Appels jonagold", Price = 0.27M, CategoryId = 2, PriceTypeId = 2 , Supermarket = Supermarket.Delhaize , IsActive = true },
                    new ProductDbDTO { Name = "Milk", Price = 1.20M, CategoryId = 3, PriceTypeId = 1 , Supermarket = Supermarket.Delhaize , IsActive = true },
                    new ProductDbDTO { Name = "Carrots", Price = 0.99M, CategoryId = 1, PriceTypeId = 2 , Supermarket = Supermarket.Colruyt , IsActive = true },
                    new ProductDbDTO { Name = "Oranges", Price = 1.50M, CategoryId = 2, PriceTypeId = 2 , Supermarket = Supermarket.Delhaize , IsActive = true },
                    new ProductDbDTO { Name = "Cheese", Price = 2.75M, CategoryId = 3, PriceTypeId = 1 , Supermarket = Supermarket.Colruyt , IsActive = true }
                };

            _dbContext.Categories.AddRange(categories);
            _dbContext.PriceTypes.AddRange(priceTypes);
            _dbContext.Products.AddRange(products);
            _dbContext.SaveChanges();
        }



    }
}
