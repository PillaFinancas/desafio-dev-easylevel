using System;
                    
public class Program
{
    private static bool rodando;
    private static string resposta;
    
    public static void Main()
    {
        rodando = true;
        escrever("Sistema de Reajuste de Salários - Empresa ADA | Desafio Pilla");
        while(rodando)
        {
            escrever("Escolha uma das opções abaixo:");
            escrever("(1) - Fazer reajuste de salário.");
            escrever("(2) - Ver lista de reajuste de salários.");
            escrever("(3) - Sair.");
            
            resposta = perguntar("");
            switch(resposta)
            {
                case "1":
                    reajustarSalario();
                    break;
                case "2":
                    mostrarTabelaReajustes();
                    break;
                case "3":
                    escrever("Saindo...");
                    rodando = false;
                    break;
            }
        }
    }
    
    public static void reajustarSalario()
    {
        double salario = Double.Parse(perguntar("Digite o salário a ser reajustado:"));
        double taxaReajuste = 0;
        if(salario <= 0)
        {
            escrever("Erro: O salário deve ser maior 0!");
            return;
        }
        if(salario <= 1999.99)         //salário de até R$1999.99
        {
            taxaReajuste = 20;
        }else if(salario <= 3999.99)  //salário de até R$3999.99
        {
            taxaReajuste = 15;
        }else if(salario <= 6999.99)  //salário de até R$6999.99
        {
            taxaReajuste = 10;
        }else{                        //salário maior de R$7000.00
            taxaReajuste = 5;
        }
        salario = salario * ( 1 + taxaReajuste / 100 );
        escrever("O salário foi reajustado para: R$" + " " + salario);
    }
    
    public static void mostrarTabelaReajustes()
    {
        escrever("Tabela de reajustes:");
        escrever("De R$0 até R$1.999,99        | Reajuste: 20%");
        escrever("De R$2.000 até R$3.999,99    | Reajuste: 15%");
        escrever("De R$4.000 até R$6.999,99    | Reajuste: 10%");
        escrever("De R$7.000 até INFINITO      | Reajuste:  5%");
        escrever("");
    }
    
    public static void escrever(string frase)
    {
        Console.WriteLine(frase);
    }
    
    public static string perguntar(string pergunta)
    {
        escrever(pergunta);
        return Console.ReadLine();
    }
}