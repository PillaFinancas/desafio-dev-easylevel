using ADA.Pagamentos.API.Domain.Entities;
using ADA.Pagamentos.API.Domain.Enums;
using ADA.Pagamentos.API.Domain.Interfaces.Repositories;
using ADA.Pagamentos.API.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADA.Pagamentos.API.Domain.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<Pessoa>> ReajustarSalarioPorValor(double salario)
        {
            var (salarioMinimo, salarioMaximo) = ObterFiltroDeSalario(salario);

            var pessoas = await _repository.ObterPessoasPorSalario(salarioMinimo, salarioMaximo);

            if (!pessoas.Any()) return null;

            foreach (var pessoa in pessoas)
            {
                pessoa.SalarioAnterior = pessoa.SalarioAtual;
                pessoa.SalarioAtual = ReajustarSalario(pessoa.SalarioAtual);
            }

            await _repository.AtualizarPessoas(pessoas);

            return pessoas;
        }

        public async Task<Pessoa> ReajustarSalarioPorPessoaId(int pessoaId)
        {
            var pessoa = await _repository.ObterPorId(pessoaId);

            if (pessoa is null) return null;

            pessoa.SalarioAnterior = (double) pessoa.SalarioAtual;
            pessoa.SalarioAtual = ReajustarSalario(pessoa.SalarioAtual);

            await _repository.Atualizar(pessoa);

            return pessoa;
        }

        public async Task<IList<Pessoa>> ReajustarSalarioPorPorcentagem(int porcetagem)
        {
            var(salarioMinimo, salarioMaximo) = ObterFiltroDeSalarioPorPorcentagem(porcetagem);

            if (salarioMaximo == 0) return null;//possivel implementação de um fluent validation para barrar na controller ou notification

            var pessoas = await _repository.ObterPessoasPorSalario(salarioMinimo, salarioMaximo);

            if (!pessoas.Any()) return null;

            foreach (var pessoa in pessoas)
            {
                pessoa.SalarioAnterior = pessoa.SalarioAtual;
                pessoa.SalarioAtual = ReajustarSalario(pessoa.SalarioAtual);
            }

            await _repository.AtualizarPessoas(pessoas);

            return pessoas;
        }

        public async Task<IList<Pessoa>> ReajustarSalarioColetivo()
        {
            var pessoas = await _repository.ObterTodos();

            if (!pessoas.Any()) return null;

            foreach (var pessoa in pessoas)
            {
                pessoa.SalarioAnterior = pessoa.SalarioAtual;
                pessoa.SalarioAtual = Math.Round(ReajustarSalario(pessoa.SalarioAtual), 2);
            }

            await _repository.AtualizarPessoas(pessoas);

            return pessoas;
        }

        public async Task<IList<Pessoa>> ObterTodos()
        {
            var pessoas = await _repository.ObterTodos();

            return pessoas;
        }

        private (double, double) ObterFiltroDeSalario(double salario)
        {
            if (salario <= 1999.99)
                return (0, 1999.99);

            else if (salario <= 3999.99)
                return (2000, 3999.99);

            else if (salario <= 6999.99)
                return (4000, 6999.99);

            else
                return (7000, double.MaxValue);
        }

        private (double, double) ObterFiltroDeSalarioPorPorcentagem(int porcentagem)
        {
            var result =  (0.0, 0.0);

            switch (porcentagem)
            {
                case (int)ReajusteSalarioEnum.CincoPorCento:
                    result = (7000.0, double.MaxValue);
                    break;
                case (int)ReajusteSalarioEnum.DezPorCento:
                    result = (4000.0, 6999.99);
                    break;
                case (int)ReajusteSalarioEnum.QuinzePorCento:
                    result = (2000.0, 3999.99);
                    break;
                case (int)ReajusteSalarioEnum.VintePorCento:
                    result = (0.0, 1999.99);
                    break;
            }

            return result;
        }

        public async Task<IList<Pessoa>> CriarPessoasTeste()
        {
            var pessoasIsExists = await _repository.ObterTodos();

            if (pessoasIsExists.Any()) return null;

            var pessoas = new List<Pessoa>();

            pessoas.Add(new Pessoa { Id = 1, Nome = "Lucas Santi", SalarioAnterior = 0, SalarioAtual = 1999.99 });
            pessoas.Add(new Pessoa { Id = 2, Nome = "Claudia Santi", SalarioAnterior = 0, SalarioAtual = 3999.99 });
            pessoas.Add(new Pessoa { Id = 3, Nome = "Valdir Santi", SalarioAnterior = 0, SalarioAtual =  6999.99});
            pessoas.Add(new Pessoa { Id = 4, Nome = "Valdir Santi JR", SalarioAnterior = 0, SalarioAtual = 11999.99 });

            await _repository.CriarPessoas(pessoas);

            return pessoas;
        }

        private double ReajustarSalario(double salario)
        {
            if (salario <= 1999.99)
                return ExecutarReajuste(salario, (int)ReajusteSalarioEnum.VintePorCento);

            else if (salario <= 3999.99)
                return ExecutarReajuste(salario, (int)ReajusteSalarioEnum.QuinzePorCento);

            else if (salario <= 6999.99)
                return ExecutarReajuste(salario, (int)ReajusteSalarioEnum.DezPorCento);

            else
                return ExecutarReajuste(salario, (int)ReajusteSalarioEnum.CincoPorCento);
        }

        private double ExecutarReajuste(double salarioBase, int valorReajuste)
        {
            var reajuste = salarioBase * ((double)valorReajuste / 100);
            var salarioReajuste = salarioBase + reajuste;

            return salarioReajuste;
        }
    }
}
