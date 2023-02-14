using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaProject
{
    class FivePercentOffMoreThan50Dollars : IDiscountPolicy
    {
        public DiscountPolicyData Get(Order order)
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
