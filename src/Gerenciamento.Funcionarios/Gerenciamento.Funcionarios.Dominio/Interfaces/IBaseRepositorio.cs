using System.Linq.Expressions;

namespace Gerenciamento.Funcionarios.Dominio.Interfaces
{
    public interface IBaseRepositorio<TEntity> where TEntity : class
    {
        Task<TEntity> FindOneAsync(Guid id);

        Task AddOneAsync(TEntity entity);

        Task ReplaceOneAsync(Expression<Func<TEntity, bool>> filterExpression,
            TEntity entity);

        Task DeleteAsync(Expression<Func<TEntity, bool>> filterExpression);
    }
}
