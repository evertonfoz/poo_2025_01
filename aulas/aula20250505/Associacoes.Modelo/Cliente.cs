using System;

namespace Associacoes.Modelo;

public class Cliente(string nome, Endereco endereco)
{
    public  string Nome { get; set; } = nome;
    public  Endereco Endereco { get; set; } = endereco;
}
