using System;

namespace Desafio_Pilla
{
    class Program
    {
        static void Main(string[] args)
        {

            double salarioAtual;
            
            Console.WriteLine("Informe o salário do funcionário para reajuste");

            salarioAtual = double.Parse(Console.ReadLine());

            if (salarioAtual <= 1999.99)
            {
                salarioAtual = salarioAtual * 1.20;

                Console.WriteLine("O salário reajustado é: " + salarioAtual);
            }

            else if (salarioAtual <= 3999.99)
                {
                salarioAtual = salarioAtual * 1.15;

                Console.WriteLine("O salário reajustado é: " + salarioAtual);
            }

            else if (salarioAtual <= 6999.99)
                {
                salarioAtual = salarioAtual * 1.10;

                Console.WriteLine("O salário reajustado é: " + salarioAtual);
            }

            else if (salarioAtual >= 7000.00)
            {
                salarioAtual = salarioAtual * 1.05;

                Console.WriteLine("O salário reajustado é: " + salarioAtual);
            }

            Console.ReadLine();
        }
    }
}
