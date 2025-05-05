using System;

namespace Associacoes.Modelo;

public class Venda
{
    private readonly List<Produto> _produtos = [];
    public required Cliente Cliente { get; set; }
    public DateTime Data { get;  } = DateTime.Now;
    public IReadOnlyList<Produto> Produtos
    {
        get
        {
            return _produtos;
        }
    }

    public void AdicionarProduto(Produto produto) {
        if (produto.Preco == null) {
            throw new ArgumentNullException($"{produto.Nome} sem preço de venda");
        }
        _produtos.Add(produto);
    }
}
