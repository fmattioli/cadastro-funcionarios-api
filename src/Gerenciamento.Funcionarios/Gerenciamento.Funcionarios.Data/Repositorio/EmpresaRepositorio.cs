using Gerenciamento.Funcionarios.Dominio.Entidades;
using Gerenciamento.Funcionarios.Dominio.Interfaces;
using MongoDB.Driver;

namespace Gerenciamento.Funcionarios.Data.Repositorio
{
    public class EmpresaRepositorio(IMongoDatabase mongoDatabase) : BaseRepositorio<Empresa>(mongoDatabase, "Empresas"), IEmpresaRepositorio
    {
    }
}
