using System;
using System.Collections.Generic;
using System.Text;

namespace ReajusteSalarial.Servico
{
    public class CalcularReajuste
    {
        public static double  Calcular(double salario)
        {
            if (salario >= 0 && salario <= 1999.99)
            {
                return (salario * 0.2) + salario;
            }
            else if (salario >= 2000 && salario <= 3999.99)
            {
                return (salario * 0.15) + salario;
            }
            else if (salario >= 4000 && salario <= 6999.99)
            {
                return (salario * 0.10) + salario;
            }
            else
            {
                return (salario * 0.5) + salario;
            }
        }
    }
}
