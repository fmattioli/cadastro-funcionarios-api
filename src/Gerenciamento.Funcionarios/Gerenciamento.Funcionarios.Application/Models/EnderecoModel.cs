namespace Gerenciamento.Funcionarios.Application.Models
{
    public class EnderecoModel(string rua, string cidade, string estado, string cep)
    {
        public string Rua { get; init; } = rua;
        public string Cidade { get; init; } = cidade;
        public string Estado { get; init; } = estado;
        public string CEP { get; init; } = cep;
    }
}
