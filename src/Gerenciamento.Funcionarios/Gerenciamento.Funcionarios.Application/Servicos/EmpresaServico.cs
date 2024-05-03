using Gerenciamento.Funcionarios.Application.Interfaces;
using Gerenciamento.Funcionarios.Application.Mappers;
using Gerenciamento.Funcionarios.Application.Models.Requests;
using Gerenciamento.Funcionarios.Application.Models.Responses;
using Gerenciamento.Funcionarios.Dominio.Entidades;
using Gerenciamento.Funcionarios.Dominio.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Gerenciamento.Funcionarios.Application.Servicos
{
    public class EmpresaServico(IEmpresaRepositorio empresaRepositorio) : IEmpresaServico
    {
        private readonly IEmpresaRepositorio _empresaRepositorio = empresaRepositorio;

        public async Task<EmpresaResponse> FindAsync(Guid id)
        {
            var empresa = await _empresaRepositorio.FindOneAsync(id);
            return empresa.ToEmpresaResponse();
        }

        public async Task AddAsync(EmpresaRequest empresa)
        {
            var empresaDominio = empresa.ToEmpresaDominio();
            await _empresaRepositorio.AddOneAsync(empresaDominio);
        }

        public async Task UpdateAsync(EmpresaRequest empresa)
        {
            var filter = new FilterDefinitionBuilder<Empresa>()
                .Where(x => x.Id == empresa.Id);

            var empresaDominio = empresa.ToEmpresaDominio();
            await _empresaRepositorio.ReplaceOneAsync(_ => filter.Inject(), empresaDominio);
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = new FilterDefinitionBuilder<Empresa>()
                .Where(x => x.Id == id);

            await _empresaRepositorio.DeleteAsync(_ => filter.Inject());
        }
    }
}
