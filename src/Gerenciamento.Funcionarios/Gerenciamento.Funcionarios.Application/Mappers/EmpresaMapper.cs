using Gerenciamento.Funcionarios.Application.Models;
using Gerenciamento.Funcionarios.Application.Models.Requests;
using Gerenciamento.Funcionarios.Dominio.Entidades;
using Gerenciamento.Funcionarios.Dominio.ValueObjects;

namespace Gerenciamento.Funcionarios.Application.Mappers
{
    public static class EmpresaMapper
    {
        public static Empresa ToEmpresaDominio(this EmpresaRequest empresa)
        {
            var enderecoEmpresas = empresa.Enderecos.Select(x => x.ToEnderecoDominio());
            return new Empresa(empresa.Id, empresa.Nome, empresa.CNPJ, enderecoEmpresas);
        }

        public static Endereco ToEnderecoDominio(this EnderecoModel endereco)
        {
            return new Endereco(endereco.Rua, endereco.Cidade, endereco.Estado, endereco.CEP);
        }

        public static EmpresaRequest ToEmpresaRequest(this Empresa empresa)
        {
            var enderecoEmpresas = empresa.Enderecos.Select(x => x.ToEnderecoModel());
            return new EmpresaRequest(empresa.Id, empresa.Nome, empresa.CNPJ, enderecoEmpresas);
        }

        public static EnderecoModel ToEnderecoModel(this Endereco endereco)
        {
            return new EnderecoModel(endereco.Rua, endereco.Cidade, endereco.Estado, endereco.CEP);
        }
    }
}
