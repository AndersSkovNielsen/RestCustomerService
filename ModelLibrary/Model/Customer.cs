using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.Model
{
    //HUSK AT GØRE LIBRARY CLASSES PUBLIC!!!
    public class Customer
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Year { get; set; }

        //Default
        public Customer()
        {
                
        }

        public Customer(int id, string firstName, string lastName, int year)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Year = year;
        }

        public override string ToString()
        {
            return $"{ID}: {FirstName} {LastName}, {Year}";
        }

        //Equal ved samme ID
        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;

            if (customer == null)
            {
                return false;
            }

            return ID == customer.ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
