namespace Gerenciamento.Funcionarios.Application.Models.Requests
{
    public class EmpresaRequest(Guid id, string nome, string cnpj, IEnumerable<EnderecoModel> enderecos)
    {
        public Guid Id { get; set; } = id;
        public string Nome { get; set; } = nome;
        public string CNPJ { get; set; } = cnpj;
        public IEnumerable<EnderecoModel> Enderecos { get; set; } = enderecos;
    }
}
