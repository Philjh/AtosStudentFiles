using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceProject
{
    public class Product
    {
        public decimal Price { get; }
        ITaxRules taxRules { get; }

        public Product(decimal price, ITaxRules taxRules)
        {
            Price = price;
            this.taxRules = taxRules;
        }

        public decimal GetTotalTax()
        {
            return taxRules.RegionalTax + (decimal)taxRules.VAT * Price;
        }


    }
}
