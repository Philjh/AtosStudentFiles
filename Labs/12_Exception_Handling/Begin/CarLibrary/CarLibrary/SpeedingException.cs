using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class SpeedingException : Exception
    {
        public SpeedingException(int excessSpeed)
        {
            ExcessSpeed = excessSpeed;
        }


        public SpeedingException(int excessSpeed, Car car)
        {
            ExcessSpeed = excessSpeed;
            Car = car;
        }

        public int ExcessSpeed { get; set; }
        public Car Car { get; set; }
    }
}
