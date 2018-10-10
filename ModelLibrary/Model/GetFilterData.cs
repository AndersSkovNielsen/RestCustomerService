using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.Model
{
    public class GetFilterData
    {
        private int _year;

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public GetFilterData()
        {
            
        }

        public GetFilterData(int year)
        {
            _year = year;
        }

        public override string ToString()
        {
            return $"{nameof(Year)}";
        }
    }
}
