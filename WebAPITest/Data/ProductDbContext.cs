using System;
using Microsoft.EntityFrameworkCore;
using WebAPITest.Models;

namespace WebAPITest.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext>options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
