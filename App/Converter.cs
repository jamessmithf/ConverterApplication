using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    static class Converter
    {
        public static decimal Convert(decimal value, Currency InCurrency, Currency OutCurrency)
        {
            decimal result = 0m;

            if (value == 0)
            {
                result = 0;
            }
            else if (InCurrency == OutCurrency)
            {
                result = value;
            }
            else
            {
                result = (InCurrency.rate * value) / OutCurrency.rate;
            }

            return result;
        }    
    }
}
