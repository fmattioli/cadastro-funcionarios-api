using Gerenciamento.Funcionarios.Data.Repositorio;
using Gerenciamento.Funcionarios.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Gerenciamento.Funcionarios.CrossCutting.Repositorios
{
    public static class RepositorioExtensions
    {
        public static IServiceCollection AddRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaRepositorio, EmpresaRepositorio>();
            return services;
        }
    }
}
