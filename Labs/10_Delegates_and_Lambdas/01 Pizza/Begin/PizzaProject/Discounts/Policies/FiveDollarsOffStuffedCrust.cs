using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaProject
{
    class FiveDollarsOffStuffedCrust : IDiscountPolicy
    {
        public DiscountPolicyData Get(Order order)
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
    }
}
