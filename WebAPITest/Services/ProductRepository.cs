using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Data;
using WebAPITest.Models;

namespace WebAPITest.Services
{
    public class ProductRepository : IProduct
    {
        ProductDbContext _context;

        public ProductRepository(ProductDbContext productDbContext)
        {
            _context = productDbContext;
        }

        public void Delete(int id)
        {
            Product productInDb = _context.Products.SingleOrDefault(c => c.Id == id);
            if (productInDb == null)
            {
                
            }
            _context.Products.Remove(productInDb);
            _context.SaveChanges(true);
        }

        public IEnumerable<Product> Get()
        {
            return _context.Products;
        }

        public Product Get(int id)
        {
            Product productInDB = _context.Products.SingleOrDefault(c => c.Id == id);
            if (productInDB.Id == id)
            {
                return productInDB;
            }
            return null;
        }

        public void Post([FromBody] Product product)
        {
                _context.Products.Add(product);
                _context.SaveChanges(true);
        }

        public void Put(int id, [FromBody] Product product)
        {
                _context.Products.Update(product);
                _context.SaveChanges(true);
        }
    }
}
