using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using ModelLibrary.Model;
using Newtonsoft.Json;

namespace RestCustomerConsumer
{
    class Program
    {
        private const string CustomerUri = "http://localhost:5000/api/customers/";

        static void Main(string[] args)
        {
            Console.WriteLine("Please wait for the REST service to start up.");
            Console.ReadLine();
            Console.WriteLine("Wall of text incoming!");

            IList<Customer> cList = GetCustomers();
            foreach (var customer in cList)
            {
                Console.WriteLine(customer);
            }

            Customer c = new Customer(4, "Larry", "Wrynn", 1944);
            InsertCustomer(c);

            Console.WriteLine("\n" + GetCustomer(4));

            UpdateCustomer(4, new Customer(4, "Varian", "Wrynn", 2004));
            Console.WriteLine("\n" + GetCustomer(4));

            DeleteCustomer(4);
            IList<Customer> cList2 = GetCustomers();
            foreach (var customer in cList2)
            {
                Console.WriteLine(customer);
            }

            Console.WriteLine("All good?");
            Console.ReadLine();
            Console.WriteLine("Excellent!");
            Console.ReadLine();
        }

        public static IList<Customer> GetCustomers()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync(CustomerUri + "all").Result;
                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                return cList;
            }
        }

        public static Customer GetCustomer(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync(CustomerUri + id).Result;
                Customer c = JsonConvert.DeserializeObject<Customer>(content);
                return c;
            }
        }



        public static void InsertCustomer(Customer newC)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(newC);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(CustomerUri + "new", content).Result;
            }
        }

        public static void UpdateCustomer(int id, Customer newC)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(newC);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(CustomerUri + id, content).Result;
            }
        }

        public static void DeleteCustomer(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.DeleteAsync(CustomerUri + id).Result;
            }
        }
    }
}
