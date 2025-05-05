using Associacoes.Modelo;

Endereco endereco = new()
{
    Logradouro = "Av.",
    NomeLogradouro = "Brasil",
    Numero = "3000",
    CEP = "81234567",
    Bairro = "Independência",
    Estado = "Paraná",
    Cidade = "Medianeira",
    Complemento = "L18"
};

Cliente cliente = new("Gestrudio", endereco);

Console.WriteLine(cliente.Endereco.NomeLogradouro);

Produto mouse = new() {
    Nome = "Mouse",
    // Preco = 123,
    Estoque = 10
};
mouse.AtualizarPreco(123);

Produto monitor = new() {
    Nome = "Monitor",
    // Preco = 456,
    Estoque = 5
};
Produto impressora = new() {
    Nome = "Impressora",
    // Preco = 567,
    Estoque = 12
};

Venda venda = new() {
    Cliente = cliente,
};

try
{
    venda.AdicionarProduto(mouse);
}
catch (ArgumentNullException ane)
{
    Console.WriteLine(ane.ParamName);
}

// venda.Produtos.Add(mouse);
// venda.Produtos.Add(monitor);
// venda.Produtos.Add(impressora);

Console.WriteLine(venda.Produtos.Count);

foreach (var produto in venda.Produtos)
{
    Console.WriteLine(produto.Nome);
}

Console.WriteLine(mouse.Preco);

mouse.AtualizarPreco(10);

Console.WriteLine(mouse.Preco);

// venda.Produtos[0] = monitor;

// foreach (var produto in venda.Produtos)
// {
//     Console.WriteLine(produto.Nome);
// }

