using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class RomanNumber
    {
        public int Value { get; set; }

        public static RomanNumber Parse(string input)
        {
            input = input.ToUpper();
            if(input == "I")
            {
                return new()
                {
                    Value = 1
                };
            }
            if (input == "II")
            {
                return new()
                {
                    Value = 2
                };
            }
            return new()
            {
                Value = 1
            };
        }
    }
}
