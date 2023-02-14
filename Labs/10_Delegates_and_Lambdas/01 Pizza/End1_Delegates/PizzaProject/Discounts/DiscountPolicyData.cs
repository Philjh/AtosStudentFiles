using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject
{
    public class DiscountPolicyData : IComparable<DiscountPolicyData>
    {
        public DiscountPolicyName DiscountPolicyName { get; }
        public decimal Discount { get; }

        public DiscountPolicyData(DiscountPolicyName discountPolicyName, decimal discount)
        {
            DiscountPolicyName = discountPolicyName;
            Discount = discount;
        }

        public int CompareTo(DiscountPolicyData other)
        {
            return this.Discount.CompareTo(other.Discount);
        }
  
    }
}
