import re

from Calculator import Calculator
if __name__ == "__main__":
    print("Bem-Vindo ao Reajustador de Salario")
    print("Informe o salario a ser reajustado, no padrao XXXX.XX ou digite Q para sair!")
    while True:
        value = input("Digite o salario: R$ ")
        if re.search("q|Q", value):
            print("Saindo ...")
            break
        if re.match("\d+\.\d{2}", value):
            try:
                newSalary = Calculator.readjustSalary(float(value))
                print("Novo Salario: R$ " + str(newSalary))
            except ValueError as err:
                print("Erro: ", err)
        else:
            print("Erro: Comando Invalido")
