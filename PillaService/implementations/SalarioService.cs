using PillaService.Contratos;

namespace PillaService;
public class SalarioService : ISalarioService
{
    public double ReajusteSalario(double salarioAtual)
    {
        if (salarioAtual > 0 && salarioAtual <= 1999.99)
            return salarioAtual + salarioAtual * 0.20;
        else if (salarioAtual > 1999.99 && salarioAtual <= 3999.99)
            return salarioAtual + salarioAtual * 0.15;
        else if (salarioAtual > 3999.99 && salarioAtual <= 6999.99)
            return salarioAtual + salarioAtual * 0.10;
        else
            return salarioAtual + salarioAtual * 0.05;
    }
}
