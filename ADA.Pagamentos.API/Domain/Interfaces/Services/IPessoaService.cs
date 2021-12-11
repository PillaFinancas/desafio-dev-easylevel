using ADA.Pagamentos.API.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADA.Pagamentos.API.Domain.Interfaces.Services
{
    public interface IPessoaService
    {
        Task<IList<Pessoa>> ReajustarSalarioPorValor(double salarioBase);

        Task<Pessoa> ReajustarSalarioPorPessoaId(int pessoaId);

        Task<IList<Pessoa>> ReajustarSalarioPorPorcentagem(int porcetagem);

        Task<IList<Pessoa>> ReajustarSalarioColetivo();

        Task<IList<Pessoa>> ObterTodos();

        Task<IList<Pessoa>> CriarPessoasTeste();
    }
}
