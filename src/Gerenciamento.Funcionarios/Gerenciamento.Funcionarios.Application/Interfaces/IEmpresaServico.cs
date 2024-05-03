using Gerenciamento.Funcionarios.Application.Models.Requests;
using Gerenciamento.Funcionarios.Application.Models.Responses;

namespace Gerenciamento.Funcionarios.Application.Interfaces
{
    public interface IEmpresaServico
    {
        Task<EmpresaResponse> FindAsync(Guid id);
        Task AddAsync(EmpresaRequest empresa);
        Task UpdateAsync(EmpresaRequest empresa);
        Task DeleteAsync(Guid id);
    }
}
