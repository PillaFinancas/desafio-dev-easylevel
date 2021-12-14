using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TestePilla.Models
{
    public static class CalculaReajuste
    {
        public static string CalcularReajuste(string salarioReajustado) 
        {
            NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            CultureInfo provider = new CultureInfo("pt-BR");           

            decimal number = Decimal.Parse(salarioReajustado, style, provider);

            if (number >= 0 && number < 2000)
            {
                number = number * 1.2m;
            }
            else if (number >= 2000 && number < 4000)
            {
                number = number * 1.15m;
            }
            else if (number >= 4000 && number < 7000)
            {
                number = number * 1.1m;
            }
            else if (number >= 7000)
            {
                number = number * 1.05m;
            }

            return String.Format("{0:N2}", number);
        }
    }
}
