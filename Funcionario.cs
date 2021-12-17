using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReajusteSalarialPilla_Console
{
    class Funcionario
    {

        string nome;
        double salario;

        public void recebe()
        {
            Console.WriteLine("\nDigite o nome do Funcionário: ");
            this.nome = Console.ReadLine();

            Console.WriteLine("\nDigite o salário do funcionário: ");
            this.salario = double.Parse(Console.ReadLine());
        }

        public string mostrar()
        {
            string mostra = "Dados do funcionário: " + this.nome + ";" + "\nSalário: " + this.salario.ToString("C") + ".";
            return mostra;
        }

        public string calculaRejuste()
        {
            string texto = "";
            double total;

            if (this.salario <= 1999.99)
            {
                total = 0.2 * this.salario;
                this.salario = salario + total;

                texto = "Com o reajuste de 20% o salário fica no valor de " + this.salario.ToString("C");
            }
            else if (salario >= 3999.99)
            {
                total = this.salario * 0.15;
                this.salario = salario + total;

                texto = "Com o reajuste de 15% o salário fica no valor de " + this.salario.ToString("C");

            }
            else if (this.salario <= 6999.99)
            {
                total = this.salario * 0.1;
                this.salario = salario + total;

                texto = "Com o reajuste de 10% o salário fica no valor de " + this.salario.ToString("C");
            }
            else
            {
                total = this.salario * 0.05;
                this.salario = salario + total;

                texto = "Com o reajuste de 5% o salário fica no valor de " + this.salario.ToString("C");
            }
            return texto;
        }

    }
}
