using Gerenciamento.Funcionarios.CrossCutting.Model;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Gerenciamento.Funcionarios.CrossCutting.Mongo
{
    public static class MongoExtensions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, MongoSettings mongoSettings)
        {
            var clientSettings = MongoClientSettings.FromConnectionString(mongoSettings.ConnectionString);
            var mongoClient = new MongoClient(clientSettings);
            services.AddSingleton<IMongoClient>(_ => mongoClient);

            services.AddSingleton(sp =>
            {
                var mongoClient = sp.GetService<IMongoClient>();
                var db = mongoClient!.GetDatabase(mongoSettings.DataBaseName);
                return db;
            });

            return services;
        }
    }
}
