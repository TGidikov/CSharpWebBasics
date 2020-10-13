using Andreys.Data;
using Andreys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext dbContext;
        public ProductsService(AndreysDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        public int Add(string name, string description, string imageUrl, decimal price, string category, string gender)
        {
            var genderAsEnum = Enum.Parse<Gender>(gender);
            var categoryAsEnum = Enum.Parse<Category>(category);
            var product = new Product()
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Price = price,
                Category = categoryAsEnum,
                Gender = genderAsEnum

            };

            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();

            return product.Id;

        }

        public IEnumerable<Product> GetAll()
        => this.dbContext.Products.ToArray();

        public Product GetById(int id) => this.dbContext.Products.FirstOrDefault(x => x.Id == id);

        public void DeleteById(int id)
        {
            var product = this.dbContext.Products.FirstOrDefault(x => x.Id == id);

            if (product!=null)
            {
                dbContext.Remove(product);
                dbContext.SaveChanges();
            }
        }
    }
}
