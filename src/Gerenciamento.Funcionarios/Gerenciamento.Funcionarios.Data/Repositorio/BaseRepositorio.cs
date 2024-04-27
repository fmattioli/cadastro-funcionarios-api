using Gerenciamento.Funcionarios.Dominio.Interfaces;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Gerenciamento.Funcionarios.Data.Repositorio
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _collection;

        public BaseRepositorio(IMongoDatabase mongoDb, string collectionName)
        {
            MapClasses();
            _collection = mongoDb.GetCollection<TEntity>(collectionName);
        }

        public async Task<TEntity> FindOneAsync(Guid id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var result = await _collection.Find(filter).FirstOrDefaultAsync();

            return result;
        }

        public async Task AddOneAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> filterExpression)
        {
            await _collection.DeleteOneAsync(filterExpression);
        }

        public async Task ReplaceOneAsync(Expression<Func<TEntity, bool>> filterExpression, TEntity entity)
        {
            await _collection.ReplaceOneAsync(filterExpression, entity);
        }

        private static void MapClasses()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(TEntity)))
            {
                BsonClassMap.TryRegisterClassMap<TEntity>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}
