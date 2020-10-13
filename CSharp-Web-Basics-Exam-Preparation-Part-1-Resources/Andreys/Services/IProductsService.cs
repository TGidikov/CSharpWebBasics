using Andreys.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Services
{
    public interface IProductsService
    {
        int Add(string name, string description, string imageUrl, decimal Price, string Category, string Gender);

        IEnumerable<Product> GetAll();

        Product GetById(int id);

        void DeleteById(int id);
    }

   

}

