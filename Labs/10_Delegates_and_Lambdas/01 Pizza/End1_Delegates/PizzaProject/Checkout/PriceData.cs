using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaProject
{
    public class PriceData
    {
        public decimal OriginalPrice { get; }
        public decimal Discount { get; }
        public decimal TotalPrice => OriginalPrice - Discount;
        public DiscountPolicyName DiscountPolicyName { get; }

        public PriceData(DiscountPolicyName discountPolicyName, decimal originalPrice, decimal discount)
        {
            DiscountPolicyName = discountPolicyName;
            OriginalPrice = originalPrice;
            Discount = discount;
        }

    }
}
