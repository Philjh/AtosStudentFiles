using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject
{
    public abstract class BestDiscount
    {
        protected List<IDiscountPolicy> policies { get; private set; } = new List<IDiscountPolicy>();

        public BestDiscount()
        {
            policies.Add(new CheapestIsFree());
        }
        public DiscountPolicyData GetBestDiscount(Order order)
        {
            // Loop round all discount policies to determine the maximum discount
            DiscountPolicyData discountPolicyWithMaxDiscount = new DiscountPolicyData(DiscountPolicyName.None, 0);
            foreach (IDiscountPolicy policy in policies)
            {
                DiscountPolicyData thisOrdersPolicyData = policy.Get(order);
                if (thisOrdersPolicyData.Discount > discountPolicyWithMaxDiscount.Discount)
                {
                    discountPolicyWithMaxDiscount = thisOrdersPolicyData;
                }
            }
            return discountPolicyWithMaxDiscount;
        }
    }

    public class WeekdayDiscounts : BestDiscount
    {
        public WeekdayDiscounts()
        {
            policies.Add(new FivePercentOffMoreThan50Dollars());
            policies.Add(new FiveDollarsOffStuffedCrust());
        }
    }

    public class WeekendDiscounts : BestDiscount
    {
    }
}
