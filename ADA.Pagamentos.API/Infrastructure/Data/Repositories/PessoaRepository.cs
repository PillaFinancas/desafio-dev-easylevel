using ADA.Pagamentos.API.Domain.Entities;
using ADA.Pagamentos.API.Domain.Interfaces.Repositories;
using ADA.Pagamentos.API.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.Pagamentos.API.Infrastructure.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ADAContext _context;

        public PessoaRepository(ADAContext context)
        {
            _context = context;
        }

        public async Task<Pessoa> ObterPorId(int id)
        {
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(x => x.Id == id);

            return pessoa;
        }

        public async Task<IList<Pessoa>> ObterTodos()
        {
            var pessoas = await _context.Pessoas.ToListAsync();

            return pessoas;
        }

        public async Task<bool> Atualizar(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);

            var result = await _context.SaveChangesAsync();

            if (result > 0) return true;

            return false;
        }

        public async Task AtualizarPessoas(IList<Pessoa> pessoas)
        {
            _context.Pessoas.UpdateRange(pessoas);

            await _context.SaveChangesAsync();
        }

        public async Task<IList<Pessoa>> ObterPessoasPorSalario(double salarioMinimo, double salarioMaximo)
        {
            var pessoas = await _context.Pessoas.Where(x => x.SalarioAtual >= salarioMinimo && x.SalarioAtual <= salarioMaximo).ToListAsync();

            return pessoas;
        }

        public async Task CriarPessoas(IList<Pessoa> pessoas)
        {
            await _context.Pessoas.AddRangeAsync(pessoas);

            await _context.SaveChangesAsync();
        }
    }
}
