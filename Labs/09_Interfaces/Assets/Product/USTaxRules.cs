using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceProject
{
    public class USTaxRules : ITaxRules
    {
        public double VAT => 0.15;

        public decimal RegionalTax => 0M;

    }
}
