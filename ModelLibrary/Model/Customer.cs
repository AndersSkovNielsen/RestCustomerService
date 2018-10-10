using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.Model
{
    //HUSK AT GØRE LIBRARY CLASSES PUBLIC!!!
    public class Customer
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private int _year;

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public Customer()
        {
                
        }

        public Customer(int id, string firstName, string lastName, int year)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _year = year;
        }

        public override string ToString()
        {
            return $"{ID}: {FirstName} {LastName}, {Year}";
        }
    }
}
