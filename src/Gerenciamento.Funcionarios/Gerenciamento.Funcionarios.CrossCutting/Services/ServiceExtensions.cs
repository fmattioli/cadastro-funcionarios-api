using Gerenciamento.Funcionarios.Application.Interfaces;
using Gerenciamento.Funcionarios.Application.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Gerenciamento.Funcionarios.CrossCutting.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServicos(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaServico, EmpresaServico>();
            return services;
        }
    }
}
