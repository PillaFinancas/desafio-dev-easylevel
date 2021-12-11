using ADA.Pagamentos.API.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADA.Pagamentos.API.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        Task<IList<Pessoa>> ObterPessoasPorSalario(double salarioMinimo, double salarioMaximo);

        Task AtualizarPessoas(IList<Pessoa> pessoas);

        Task<Pessoa> ObterPorId(int id);

        Task<bool> Atualizar(Pessoa pessoa);

        Task<IList<Pessoa>> ObterTodos();

        Task CriarPessoas(IList<Pessoa> pessoas);
    }
}
