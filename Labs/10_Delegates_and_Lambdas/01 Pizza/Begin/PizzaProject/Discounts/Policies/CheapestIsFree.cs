using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaProject
{
    class CheapestIsFree : IDiscountPolicy
    {
        public DiscountPolicyData Get(Order order)
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
    }
}
