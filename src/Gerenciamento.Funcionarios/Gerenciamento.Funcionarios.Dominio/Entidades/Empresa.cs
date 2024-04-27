using Gerenciamento.Funcionarios.Dominio.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace Gerenciamento.Funcionarios.Dominio.Entidades
{
    public class Empresa(Guid id, string nome, string cnpj, IEnumerable<Endereco> endereco)
    {
        [BsonId]
        public Guid Id { get; set; } = id;
        public string Nome { get; set; } = nome;
        public string CNPJ { get; set; } = cnpj;
        public IEnumerable<Endereco> Enderecos { get; set; } = endereco;
    }
}
