using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ReajusteSalarial.Dominio;
using ReajusteSalarial.Servico;

namespace ReajusteSalarial
{
    public static class Function1
    {
        [FunctionName("ReajusteSalarial")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "reajuste")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var requestbody = await new StreamReader(req.Body).ReadToEndAsync();
                var salario = JsonConvert.DeserializeObject<Salario>(requestbody);
                if (salario.Valor == null)
                    throw new Exception("Valor do Salario Está Vazio");

                if (salario.Valor < 0)
                    throw new Exception("Valor do Salario Está Negativo");

                double reajuste = CalcularReajuste.Calcular(salario.Valor);

                return new OkObjectResult(reajuste);

            }
            catch (Exception ex)
            {
                var result = new ObjectResult(ex.Message);
                result.StatusCode = StatusCodes.Status400BadRequest;
                return result;
            }
                
        }

    }
}
