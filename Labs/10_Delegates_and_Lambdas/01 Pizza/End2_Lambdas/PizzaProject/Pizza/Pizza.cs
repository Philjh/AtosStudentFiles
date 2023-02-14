using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject
{
    public class Pizza
    {

        public Size Size { get; }
        public Crust Crust { get; }
        public Pizza(Size size, Crust crust)
        {
            Size = size;
            Crust = crust;
        }
        public decimal Price
        {
            get
            {
                decimal price;
                switch (Size)
                {
                    case Size.Small_10: price = 10; break;
                    case Size.Medium_15: price = 15; break;
                    case Size.Large_20: price = 20; break;
                    default: throw new Exception("Bad Size");
                }
                switch (Crust)
                {
                    case Crust.Regular_2: price += 2; break;
                    case Crust.Stuffed_3: price += 3; break;
                    case Crust.Thin_4: price += 4; break;
                    default: throw new Exception("Bad Crust");
                }
                return price;
            }
        }
    }
}
