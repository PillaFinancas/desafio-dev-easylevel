class Calculator:
    def __init__(self) -> None:
        pass
    @staticmethod
    def percentage(val: float, p: float) -> float:
        if(p < 0 or val < 0):
            raise ValueError("O valor ou o percentual devem ser positivos!")
        return val * p
    
    @staticmethod
    def readjustSalary(salary: float) -> float:
        if(salary < 0):
            raise ValueError("O salario nao deve ser negativo!")
        elif(salary >= 0 and salary < 2000):
            return salary + Calculator.percentage(salary, 0.2)
        elif(salary >= 2000 and salary < 4000):
            return salary + Calculator.percentage(salary, 0.15)
        elif(salary >= 4000 and salary < 7000):
            return salary + Calculator.percentage(salary, 0.10)
        else:
            return salary + Calculator.percentage(salary, 0.05)