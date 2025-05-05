namespace Associacoes.Modelo;

public class Endereco
{
    public required string Logradouro { get; set; }
    public required string NomeLogradouro { get; set; }
    public required string Numero { get; set; }
    public string  Complemento { get; set; } =  string.Empty;
    public required string CEP { get; set; }
    public required string Bairro { get; set; }
    public required string Estado { get; set; }
    public required string Cidade { get; set; }
}
