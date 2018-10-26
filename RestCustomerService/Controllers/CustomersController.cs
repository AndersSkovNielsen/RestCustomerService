using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Husk using til library reference, muligvis til folder
using ModelLibrary.Model;
using DisableCorsAttribute = Microsoft.AspNetCore.Cors.DisableCorsAttribute;
using EnableCorsAttribute = Microsoft.AspNetCore.Cors.EnableCorsAttribute;

namespace RestCustomerService.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static List<Customer> cList = new List<Customer>()
        {
            new Customer(1, "Ace", "Williams", 1991),
            new Customer(2, "Laura", "Cleric", 2000),
            new Customer(3, "Nathan", "Rourke", 2018)
        };

        // GET: api/Customers/all
        [HttpGet]
        [Route("all")]
        public List<Customer> GetAllCustomers()
        {
            return cList;
        }

        // GET: api/Customers/5
        [HttpGet]
        [Route("{id}")]
        public Customer GetCustomer(int id)
        {
            return cList[id-1];
        }

        // GET: api/Customers?year=[year]
        [HttpGet]
        public IList<Customer> GetCustomerByYear([FromQuery] GetFilterData filter)
        {
            IList<Customer> newList = new List<Customer>();

            foreach (var customer in cList)
            {
                if (customer.Year == filter.Year)
                {
                    newList.Add(customer);
                }
            }

            return newList;
        }

        // POST: api/Customers/new
        [HttpPost]
        [Route("new")]
        [EnableCors("AllowSpecificOrigin")]
        public void InsertCustomer(Customer c)
        {
            cList.Add(c);
        }

        // PUT: api/Customers/update/5
        [HttpPut]
        [Route("update/{id}")]
        public void UpdateCustomer(int id, Customer  c)
        {
            cList[id - 1] = c;
        }

        // DELETE: api/Customers/delete/5
        [HttpDelete]
        [Route("delete/{id}")]
        [DisableCors]
        public void DeleteCustomer(int id)
        {
            cList.Remove(cList[id-1]);
        }
    }
}
