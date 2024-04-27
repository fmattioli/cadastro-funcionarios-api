using FluentValidation;
using Gerenciamento.Funcionarios.Application.Models;
using Gerenciamento.Funcionarios.Application.Models.Requests;

namespace Gerenciamento.Funcionarios.Application.Validators
{
    public class AddEmpresaValidator : AbstractValidator<EmpresaRequest>
    {
        public AddEmpresaValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O id não pode ser vazio!!!");
            
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio!!!");
            
            RuleFor(x => x.CNPJ)
                .NotNull()
                .NotEmpty()
                .WithMessage("O CNPJ não pode ser vazio!!!");
        }
    }

    public class AddEnderecoValidator : AbstractValidator<EnderecoModel>
    {
        public AddEnderecoValidator()
        {
            RuleFor(x => x.Estado)
               .NotNull()
               .NotEmpty()
               .WithMessage("O Estado não pode ser vazio ou nulo!!!");

            RuleFor(x => x.Rua)
               .NotNull()
               .NotEmpty()
               .WithMessage("A Rua não pode ser vazio ou nulo!!!");

            RuleFor(x => x.CEP)
               .NotNull()
               .NotEmpty()
               .WithMessage("O Cep não pode ser vazio ou nulo!!!");
            
            RuleFor(x => x.Estado)
               .NotNull()
               .NotEmpty()
               .WithMessage("O Estado não pode ser vazio ou nulo!!!");
        }
    }
}
