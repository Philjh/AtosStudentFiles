using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceProject
{
    public class UKTaxRules : ITaxRules
    {
        public bool ApplyEURules { get; }

        public double VAT => 0.175;

        public decimal RegionalTax => (ApplyEURules) ? 10M : 20M;

        public UKTaxRules(bool applyEURules)
        {
            ApplyEURules = applyEURules;
        }
    }
}
