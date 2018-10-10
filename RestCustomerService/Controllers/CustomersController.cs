using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Husk using til library reference, muligvis til folder
using ModelLibrary.Model;

namespace RestCustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static List<Customer> cList = new List<Customer>()
        {
            new Customer(1, "Ace", "Williams", 1991),
            new Customer(2, "Laura", "Cleric", 2000),
            new Customer(3, "Nathan", "Rourke", 2018)
        };

        // GET: api/Customers
        [HttpGet]
        [Route("all")]
        public List<Customer> Get()
        {
            return cList;
        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        [Route("{id}")]
        public Customer Get(int id)
        {
            return cList[id-1];
        }

        // POST: api/Customers
        [HttpPost]
        [Route("new")]
        public void InsertCustomer(Customer c)
        {
            cList.Add(c);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        [Route("{id}")]
        public void UpdateCustomer(int id, Customer  c)
        {
            cList[id - 1] = c;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Route("{id}")]
        public void DeleteCustomer(int id)
        {
            cList.Remove(cList[id-1]);
        }
    }
}
