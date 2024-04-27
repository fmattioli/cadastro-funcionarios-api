using Gerenciamento.Funcionarios.Application.Models.Requests;

namespace Gerenciamento.Funcionarios.Application.Interfaces
{
    public interface IEmpresaServico
    {
        Task AddAsync(EmpresaRequest empresa);
        Task UpdateAsync(EmpresaRequest empresa);
        Task DeleteAsync(Guid id);
    }
}
