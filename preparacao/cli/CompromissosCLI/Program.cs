using System.Collections;
using System.Text.Json;

internal class Program
{
    const string caminhoArquivo = "compromissos.json";
    private static void Main(string[] args)
    {
        List<Compromisso> compromissos = CarregarCompromissos();
        string? opcao;

        if (args.Length == 0)
{
    Console.WriteLine("Uso:");
    Console.WriteLine("  listar");
    Console.WriteLine("  adicionar <data> <hora> <local> <descricao>");
    Console.WriteLine("  editar <numero_exibido> <nova_data> <nova_hora> <novo_local> <nova_descricao>");
    Console.WriteLine("  excluir <numero_exibido>");
    return;
}

        string comando = args[0].ToLower();

        switch (comando)
        {
            case "listar":
                Listar(compromissos);
                break;
            case "adicionar":
                AdicionarViaArgumentos(args.Skip(1).ToArray(), compromissos);
                break;
            case "editar":
                EditarViaArgumentos(args.Skip(1).ToArray(), compromissos);
                break;
            case "excluir":
                ExcluirViaArgumentos(args.Skip(1).ToArray(), compromissos);
                break;
            default:
                Console.WriteLine("Comando não reconhecido.");
                break;
        }

        SalvarCompromissos(compromissos);


        // do
        // {
        //     Console.Clear();
        //     Console.WriteLine("=== MENU DE COMPROMISSOS ===");
        //     Console.WriteLine("1. Listar");
        //     Console.WriteLine("2. Adicionar");
        //     Console.WriteLine("3. Editar");
        //     Console.WriteLine("4. Excluir");
        //     Console.WriteLine("0. Sair");
        //     Console.Write("Escolha uma opção: ");
        //     opcao = Console.ReadLine();

        //     switch (opcao)
        //     {
        //         case "1":
        //             Listar(compromissos);
        //             break;
        //         case "2":
        //             Adicionar(compromissos);
        //             break;
        //         case "3":
        //             Editar(compromissos);
        //             break;
        //         case "4":
        //             Excluir(compromissos);
        //             break;
        //     }

        //     if (opcao != "0")
        //     {
        //         Console.WriteLine("\nPressione qualquer tecla para continuar...");
        //         Console.ReadKey();
        //     }

        // } while (opcao != "0");

        // SalvarCompromissos(compromissos);

    }

    static void AdicionarViaArgumentos(string[] args, List<Compromisso> lista)
    {
        if (args.Length < 4)
        {
            Console.WriteLine("Uso: adicionar <data> <hora> <local> <descricao>");
            return;
        }

        var compromisso = new Compromisso
        {
            Data = DateTime.Parse(args[0]),
            Hora = TimeSpan.Parse(args[1]),
            Local = args[2],
            Descricao = args[3]
        };

        lista.Add(compromisso);
        Console.WriteLine("Compromisso adicionado via CLI.");
    }

    static void EditarViaArgumentos(string[] args, List<Compromisso> lista)
{
    if (args.Length < 5)
    {
        Console.WriteLine("Uso: editar <numero_exibido> <nova_data> <nova_hora> <novo_local> <nova_descricao>");
        return;
    }

    if (!int.TryParse(args[0], out int indiceVisual) || indiceVisual < 1 || indiceVisual > lista.Count)
    {
        Console.WriteLine("Número inválido.");
        return;
    }

    int indice = indiceVisual - 1;

    lista[indice].Data = DateTime.Parse(args[1]);
    lista[indice].Hora = TimeSpan.Parse(args[2]);
    lista[indice].Local = args[3];
    lista[indice].Descricao = args[4];

    Console.WriteLine("Compromisso editado.");
}


    static void ExcluirViaArgumentos(string[] args, List<Compromisso> lista)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Uso: excluir <indice>");
            return;
        }

        if (!int.TryParse(args[0], out int indice) || indice < 0 || indice >= lista.Count)
        {
            Console.WriteLine("Índice inválido.");
            return;
        }

        lista.RemoveAt(indice);
        Console.WriteLine("Compromisso removido.");
    }


    static void SalvarCompromissos(List<Compromisso> lista)
    {
        var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(caminhoArquivo, json);
    }

    static List<Compromisso> CarregarCompromissos()
    {
        if (!File.Exists(caminhoArquivo)) return new List<Compromisso>();
        var json = File.ReadAllText(caminhoArquivo);
        return JsonSerializer.Deserialize<List<Compromisso>>(json) ?? new List<Compromisso>();
    }

    static void Listar(IList<Compromisso> lista)
    {
        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum compromisso encontrado.");
            return;
        }
        for (int i = 0; i < lista.Count; i++)
        {
            var c = lista[i];
            Console.WriteLine($"{i + 1}. {c.Data:dd/MM/yyyy} às {c.Hora} -  {c.Local} => {c.Descricao}");
        }
    }

    static void Adicionar(IList lista)
    {
        Console.Write("Data (dd/MM/yyyy): ");
        DateTime data = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Hora (HH:mm): ");
        TimeSpan hora = TimeSpan.Parse(Console.ReadLine()!);
        Console.Write("Local: ");
        string local = Console.ReadLine()!;
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine()!;
        lista.Add(new Compromisso
        {
            Data = data,
            Hora = hora,
            Local = local,
            Descricao = descricao
        });
        Console.WriteLine("Compromisso adicionado.");
    }

    static void Editar(IList<Compromisso> lista)
    {
        Listar(lista);
        Console.Write("Digite o número do compromisso que deseja editar: ");
        int indice = int.Parse(Console.ReadLine()!) - 1;
        if (indice < 0 || indice >= lista.Count)
        {
            Console.WriteLine("Índice inválido.");
            return;
        }
        Console.Write("Nova data (dd/MM/yyyy): ");
        lista[indice].Data = DateTime.Parse(Console.ReadLine()!);
        Console.Write("Nova hora (HH:mm): ");
        lista[indice].Hora = TimeSpan.Parse(Console.ReadLine()!);
        Console.Write("Novo local: ");
        lista[indice].Local = Console.ReadLine()!;
        Console.Write("Nova descrição: ");
        lista[indice].Descricao = Console.ReadLine()!;
        Console.WriteLine("Compromisso atualizado.");
    }

    static void Excluir(IList<Compromisso> lista)
    {
        Listar(lista);
        Console.Write("Digite o número do compromisso que deseja excluir: ");
        int indice = int.Parse(Console.ReadLine()!) - 1;
        if (indice < 0 || indice >= lista.Count)
        {
            Console.WriteLine("Índice inválido.");
            return;
        }
        lista.RemoveAt(indice);
        Console.WriteLine("Compromisso removido.");
    }

}

