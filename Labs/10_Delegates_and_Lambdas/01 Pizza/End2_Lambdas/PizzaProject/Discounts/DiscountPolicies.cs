using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject
{
    public static class DiscountPolicies
    {
        public static DiscountPolicyData CheapestIsFree(Order order)
        {
            System.Diagnostics.Debug.WriteLine("CheapestIsFree");
            var pizzas = order.Pizzas;
            if (pizzas.Count < 2)
            {
                return new DiscountPolicyData(DiscountPolicyName.None, 0M);
            }

            // Loop round all pizzas in the order and get the one with the minimum price
            decimal minPrice = decimal.MaxValue;
            foreach (Pizza pizza in pizzas)
            {
                if (pizza.Price < minPrice)
                {
                    minPrice = pizza.Price;
                }
            }
            return new DiscountPolicyData(DiscountPolicyName.Cheapest_Is_Free, minPrice);
        }

        public static DiscountPolicyData FiveDollarsOffStuffedCrust(Order order)
        {
            // Loop round all pizzas, discounting all those which have a stuffed crust
            decimal discount = 0;
            foreach (Pizza pizza in order.Pizzas)
            {
                if (pizza.Crust == Crust.Stuffed_3)
                {
                    discount += 5M;
                }
            }
            return new DiscountPolicyData(DiscountPolicyName.Five_Dollars_Off_StuffedCrust, discount);

        }

        public static DiscountPolicyData FivePercentOffMoreThan50Dollars(Order order)
        {
            // Loop round all pizzas finding the total
            decimal nonDiscounted = 0;
            foreach (Pizza pizza in order.Pizzas)
            {
                nonDiscounted += pizza.Price;
            }
            // if the total is more than 50 then give a 5% discount
            return new DiscountPolicyData(DiscountPolicyName.Five_Percent_Off_More_Than_50_Dollars, nonDiscounted >= 50 ? nonDiscounted * 0.05M : 0);

        }
    }
}
