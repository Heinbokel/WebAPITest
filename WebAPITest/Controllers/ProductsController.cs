using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Data;
using WebAPITest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        ProductDbContext _context;

        public ProductsController(ProductDbContext productDbContext)
        {
            _context = productDbContext;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.Products;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product productInDB = _context.Products.SingleOrDefault(c => c.Id == id);
            if(id != null && productInDB.Id == id){
                return Ok(productInDB);
            }
            return NotFound("Could not find product with that id.");
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if(product != null && ModelState.IsValid){
                _context.Products.Add(product);
                _context.SaveChanges(true);
                return StatusCode(201);
            }
            return BadRequest(ModelState);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if(product != null && ModelState.IsValid){
                _context.Products.Update(product);
                _context.SaveChanges(true);
                return Ok(); 
            }
            return BadRequest(ModelState);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product productInDb = _context.Products.SingleOrDefault(c => c.Id == id);
            if(productInDb == null){
                return NotFound();
            }
            _context.Products.Remove(productInDb);
            _context.SaveChanges(true);
            return Ok();
        }
    }
}
