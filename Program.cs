using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReajusteSalarialPilla_Console
{
    class Program
    {
        static void Main(string[] args)
        {
                Funcionario funcionario = new Funcionario();

                Console.WriteLine("Programa está sendo executado em {0} \n\n", System.DateTime.Now);

                Console.WriteLine("---------- Digite os dados para inclusão do Funcionário ----------\n\n");
                funcionario.recebe();

                string dados = "s";
                int escolha;

                while (dados == "s")
                {
                    Console.Clear();
                    Console.WriteLine("Escolha uma das opções abaixo: \n\n1 - Exibir dados do Funcionário; \n2 - Calcular reajuste; \n3 - Sair");
                    escolha = int.Parse(Console.ReadLine());

                    switch (escolha)
                    {
                        case 1:
                            Console.WriteLine(funcionario.mostrar());
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine(funcionario.calculaRejuste());
                            Console.ReadKey();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opção inválida;");
                            break;

                    }
                    Console.WriteLine("\n\nPara continuar na aplicação basta digitar s, caso queira sair, digite qualquer outra tecla: ");
                    dados = Console.ReadLine();
                }
        }
    }
}
