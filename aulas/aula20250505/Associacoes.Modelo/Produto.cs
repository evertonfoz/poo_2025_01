using System;

namespace Associacoes.Modelo;

public class Produto
{
    private double? _preco;
    public required string Nome { get; set; }
    public double? Preco { 
        get {
            return _preco;
        }
    }
    public required double Estoque { get; set; }

    public void AtualizarPreco(double preco) {
        _preco = preco;
    }
}
