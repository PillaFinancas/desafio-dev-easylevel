using ADA.Pagamentos.API.Domain.Interfaces.Repositories;
using ADA.Pagamentos.API.Domain.Interfaces.Services;
using ADA.Pagamentos.API.Domain.Services;
using ADA.Pagamentos.API.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ADA.Pagamentos.API.Infrastructure.IoC
{
    public static class Bootstrapper
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
        }
    }
}
