using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceProject
{
    public interface ITaxRules
    {
        double VAT { get; }
        decimal RegionalTax { get; }
    }
}
