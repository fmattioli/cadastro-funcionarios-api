namespace Gerenciamento.Funcionarios.Dominio.ValueObjects
{
    public record Endereco
    {
        public Endereco(string rua, string cidade, string estado, string cep)
        {
            Rua = rua;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
        }

        public string Rua { get; init; }
        public string Cidade { get; init; }
        public string Estado { get; init; }
        public string CEP { get; init; }
    }

}
