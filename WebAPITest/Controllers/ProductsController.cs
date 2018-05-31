using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Data;
using WebAPITest.Models;
using WebAPITest.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        IProduct _productRepository;

        public ProductsController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productRepository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Product product)
        {
            _productRepository.Post(product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product product)
        {
            _productRepository.Put(id,product);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
