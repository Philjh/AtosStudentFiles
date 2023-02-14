using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaProject
{
    public class Order
    {
        public List<Pizza> Pizzas { get; private set; } = new List<Pizza>();

        public decimal NonDiscountedPrice {
             get {
                // Loop round all pizzas and sum their prices to achieve a total
                decimal total = 0;
                foreach(Pizza p in Pizzas)
                {
                    total += p.Price;
                }
                return total;
            }
        }

    }
}
