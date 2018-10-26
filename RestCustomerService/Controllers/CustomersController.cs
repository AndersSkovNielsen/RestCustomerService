﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Husk using til library reference, muligvis til folder
using ModelLibrary.Model;

namespace RestCustomerService.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("AllowAnyOrigin")]
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
        public List<Customer> GetAllCustomers()
        {
            return cList;
        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        [Route("{id}")]
        public Customer GetCustomer(int id)
        {
            return cList[id-1];
        }

        // GET: api/Customers/5
        [HttpGet]
        [Route("customers")]
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
