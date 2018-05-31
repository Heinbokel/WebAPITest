using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Models;

namespace WebAPITest.Services
{
    public interface IProduct
    {
        //CRUD Services

        IEnumerable<Product> Get();

        Product Get(int id);

        void Post([FromBody]Product product);

        void Put(int id,[FromBody]Product product);

        void Delete(int id);
    }
}
