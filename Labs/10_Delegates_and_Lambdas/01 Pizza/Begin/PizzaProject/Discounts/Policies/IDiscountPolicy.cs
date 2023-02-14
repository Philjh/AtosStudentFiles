using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaProject
{
    public interface IDiscountPolicy
    {
        DiscountPolicyData Get(Order order);
    }
}
