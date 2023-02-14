using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class InvalidColourException: Exception
    {
        public InvalidColourException(string colour, Car car)
        {
            Colour = colour;
            Car = car;
        }

        public string Colour { get; set; }
        public Car Car { get; set; }
    }
}
