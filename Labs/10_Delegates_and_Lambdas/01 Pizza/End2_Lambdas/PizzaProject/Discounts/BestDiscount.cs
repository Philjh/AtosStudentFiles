using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PizzaProject.DiscountPolicies;

namespace PizzaProject
{
    public abstract class BestDiscount
    {
        protected List<Func<Order, DiscountPolicyData>> policies { get; private set; } = new List<Func<Order, DiscountPolicyData>>();

        public BestDiscount()
        {
            policies.Add(CheapestIsFree);
        }
        public DiscountPolicyData GetBestDiscount(Order order)
        {
            // Loop round all discount policies to determine the maximum discount
            DiscountPolicyData discountPolicyWithMaxDiscount = new DiscountPolicyData(DiscountPolicyName.None, 0);
            foreach (Func<Order, DiscountPolicyData> policy in policies)
            {
                DiscountPolicyData thisOrdersPolicyData = policy(order);
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
            policies.Add(FivePercentOffMoreThan50Dollars);
            policies.Add(FiveDollarsOffStuffedCrust);
        }
    }

    public class WeekendDiscounts : BestDiscount
    {
        public WeekendDiscounts()
        {
            policies.Add(order => new DiscountPolicyData(DiscountPolicyName.Weekend_10_Percent_Off, order.NonDiscountedPrice * 0.1M));
        }
    }
}
