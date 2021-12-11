using ADA.Pagamentos.API.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ADA.Pagamentos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoasController(IPessoaService service)
        {
            _service = service;
        }

        [HttpPut("ReajustarSalarioPorValor")]
        public async Task<ActionResult> ReajustarSalarioPorValor(double salarioBase)
        {
            try
            {
                var result = await _service.ReajustarSalarioPorValor(salarioBase);

                if (result != null) return Ok(result);

                return NotFound("Não existe nenhum funcionário com essa faixa de salarial no Sistema. Por favor, verifique e tente novamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ReajustarSalarioPorPessoaId")]
        public async Task<ActionResult> ReajustarSalarioPorPessoaId(int pessoaId)
        {
            try
            {
                var result = await _service.ReajustarSalarioPorPessoaId(pessoaId);

                if (result != null) return Ok(result);

                return NotFound("Este usuário não foi encontrado. Verifique o identificador e tente novamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ReajustarSalarioPorPorcentagem")]
        public async Task<ActionResult> ReajustarSalarioPorPorcentagem(int porcentagem)
        {
            try
            {
                var result = await _service.ReajustarSalarioPorPorcentagem(porcentagem);

                if (result != null) return Ok(result);

                return NotFound("Não foi possível realizar o reajuste. Por favor, verifique a porcentagem e tente novamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ReajustarSalarioColetivo")]
        public async Task<ActionResult> ReajustarSalarioColetivo()
        {
            try
            {
                var result = await _service.ReajustarSalarioColetivo();

                if (result != null) return Ok(result);

                return NotFound("Não existe funcionários cadastrados no sistema. Cadastre e tente novamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObterTodos")]
        public async Task<ActionResult> ObterTodos()
        {
            try
            {
                var pessoa = await _service.ObterTodos();

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CriarMassaParaTeste")]
        public async Task<ActionResult> CriarMassaParaTeste()
        {
            try
            {
                var pessoas = await _service.CriarPessoasTeste();

                if (pessoas != null) return Ok(pessoas);

                return NotFound("Já foi criado uma massa de Teste. Utilizado o ObterTodos e utilize a massa já existente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
