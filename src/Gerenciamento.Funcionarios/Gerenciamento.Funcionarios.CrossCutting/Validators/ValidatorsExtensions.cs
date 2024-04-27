using FluentValidation;
using FluentValidation.AspNetCore;
using Gerenciamento.Funcionarios.Application.Models;
using Gerenciamento.Funcionarios.Application.Models.Requests;
using Gerenciamento.Funcionarios.Application.Validators;

using Microsoft.Extensions.DependencyInjection;

namespace Gerenciamento.Funcionarios.CrossCutting.Validators
{
    public static class ValidatorsExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(x => x.DisableDataAnnotationsValidation = true);
            services.AddScoped<IValidator<EmpresaRequest>, AddEmpresaValidator>();
            services.AddScoped<IValidator<EnderecoModel>, AddEnderecoValidator>();
            return services;
        }
    }
}
