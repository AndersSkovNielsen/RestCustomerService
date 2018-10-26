using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary.Model
{
    public class GetFilterData
    {
        public int Year { get; set; }

        public GetFilterData()
        {
            
        }

        public GetFilterData(int year)
        {
            Year = year;
        }

        public override string ToString()
        {
            return $"{nameof(Year)}";
        }
    }
}
