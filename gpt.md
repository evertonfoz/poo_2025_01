## 📘 EBOOK: Aplicação CLI em C# — CRUD de Compromissos com Persistência em JSON

### 1️⃣ Introdução

#### O que é uma aplicação CLI?

Uma **CLI (Command Line Interface)** é um tipo de aplicação que roda diretamente no terminal ou prompt de comando. Ao invés de usar botões, janelas e menus gráficos, o usuário interage por meio de textos digitados. Isso torna esse tipo de aplicação simples, leve e ideal para aprender os fundamentos de programação, especialmente em linguagens como **C#**.

#### Por que usar C# para esse projeto?

O C# é uma linguagem poderosa, moderna e amplamente utilizada no mercado de trabalho. Com a plataforma .NET, é possível criar diversos tipos de aplicações, incluindo CLIs. Ao criar um projeto console com C#, você trabalha com:

* Entrada e saída de dados via `Console.ReadLine()` e `Console.WriteLine()`.
* Estruturação de código orientado a objetos.
* Boas práticas de engenharia de software.

#### O projeto: CRUD de Compromissos

Este projeto tem como objetivo implementar um sistema de compromissos com as seguintes funcionalidades:

* Criar novos compromissos.
* Listar compromissos existentes.
* Editar um compromisso já registrado.
* Excluir compromissos.

Cada compromisso terá:

* **Data** (ex: 20/05/2025)
* **Hora** (ex: 14:30)
* **Local** (ex: "Sala de Reuniões")
* **Descrição** (ex: "Apresentação do Projeto Final")

Os dados serão armazenados em disco, utilizando o formato **JSON**.

### 2️⃣ Fundamentos Técnicos

#### Estrutura de um Projeto Console com C\#

Uma aplicação console pode ser criada facilmente com o comando:

```bash
dotnet new console -n CompromissosCLI
```

Isso cria uma estrutura básica com um arquivo `Program.cs`, onde a aplicação é iniciada. A execução é feita com:

```bash
dotnet run
```

#### O que é JSON?

**JSON (JavaScript Object Notation)** é um formato leve e legível de troca de dados. Ele é amplamente usado para salvar informações estruturadas, como listas de objetos.

Exemplo de compromisso em JSON:

```json
{
  "Data": "2025-05-20",
  "Hora": "14:30",
  "Local": "Sala de Reuniões",
  "Descricao": "Apresentação do Projeto Final"
}
```

#### Serialização e Desserialização

Para salvar objetos em JSON, precisamos **serializar** os dados. Já para ler os dados de volta, fazemos a **desserialização**.

No C#, utilizamos a biblioteca `System.Text.Json` para isso:

```csharp
// Serializar
string json = JsonSerializer.Serialize(objeto);

// Desserializar
var objeto = JsonSerializer.Deserialize<Tipo>(json);
```

#### Manipulação de Arquivos

Para salvar dados em disco:

```csharp
File.WriteAllText("compromissos.json", json);
```

Para ler dados:

```csharp
string json = File.ReadAllText("compromissos.json");
```

#### Estrutura de Classes

Vamos representar os compromissos com uma classe:

```csharp
public class Compromisso
{
    public DateTime Data { get; set; }
    public TimeSpan Hora { get; set; }
    public string Local { get; set; }
    public string Descricao { get; set; }
}
```

### 3️⃣ Modelagem do Projeto

Neste capítulo, vamos definir a base da nossa aplicação. Aqui, estruturamos a classe `Compromisso`, preparamos a lista de objetos que representará nossos dados em memória e mostramos como persistir essas informações em disco com JSON.


#### 🧱 Estrutura da Classe `Compromisso`

A classe `Compromisso` é o coração da nossa aplicação. Ela define o que é um compromisso e quais informações ele carrega.

```csharp
public class Compromisso
{
    public DateTime Data { get; set; }
    public TimeSpan Hora { get; set; }
    public string Local { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
}
```

* `Data`: armazena apenas a data do compromisso.
* `Hora`: armazena o horário (separado da data para facilitar exibição e manipulação).
* `Local`: descrição breve do local onde o compromisso acontecerá.
* `Descricao`: detalhes do compromisso.


#### 🗂 Lista de Compromissos

Dentro da aplicação, todos os compromissos serão armazenados em uma lista do tipo `List<Compromisso>`, que servirá como nosso banco de dados em memória.

```csharp
List<Compromisso> compromissos = new();
```

#### 💾 Persistência em Arquivo (JSON)

Usaremos um arquivo chamado `compromissos.json` para salvar e carregar os dados.

##### Caminho do arquivo:

```csharp
string caminhoArquivo = "compromissos.json";



### 4️⃣ Implementação Passo a Passo

Este capítulo apresenta a implementação completa da aplicação, com um menu interativo no terminal e as funções de **Criar**, **Listar**, **Editar** e **Excluir** compromissos.


#### 📁 Estrutura Inicial do Projeto

Abra o terminal e crie a solução:

```bash
dotnet new console -n CompromissosCLI
cd CompromissosCLI
```

Adicione o namespace necessário no topo do `Program.cs`:

```csharp
using System.Text.Json;
```


#### 🧱 Classe `Compromisso`

Crie um novo arquivo chamado `Compromisso.cs`:

```csharp
public class Compromisso
{
    public DateTime Data { get; set; }
    public TimeSpan Hora { get; set; }
    public string Local { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
}
```


#### 📂 Funções de Persistência

No `Program.cs`:

```csharp
const string caminhoArquivo = "compromissos.json";

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
```


#### 📋 Menu Interativo

No `Main()`:

```csharp
List<Compromisso> compromissos = CarregarCompromissos();
string? opcao;

do
{
    Console.Clear();
    Console.WriteLine("=== MENU DE COMPROMISSOS ===");
    Console.WriteLine("1. Listar");
    Console.WriteLine("2. Adicionar");
    Console.WriteLine("3. Editar");
    Console.WriteLine("4. Excluir");
    Console.WriteLine("0. Sair");
    Console.Write("Escolha uma opção: ");
    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Listar(compromissos);
            break;
        case "2":
            Adicionar(compromissos);
            break;
        case "3":
            Editar(compromissos);
            break;
        case "4":
            Excluir(compromissos);
            break;
    }

    if (opcao != "0") {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

} while (opcao != "0");

SalvarCompromissos(compromissos);
```

#### 🔧 Funções CRUD

```csharp
static void Listar(List<Compromisso> lista)
{
    if (lista.Count == 0)
    {
        Console.WriteLine("Nenhum compromisso encontrado.");
        return;
    }

    for (int i = 0; i < lista.Count; i++)
    {
        var c = lista[i];
        Console.WriteLine($"{i + 1}. {c.Data:dd/MM/yyyy} às {c.Hora} - {c.Local} => {c.Descricao}");
    }
}

static void Adicionar(List<Compromisso> lista)
{
    Console.Write("Data (dd/MM/yyyy): ");
    DateTime data = DateTime.Parse(Console.ReadLine()!);

    Console.Write("Hora (HH:mm): ");
    TimeSpan hora = TimeSpan.Parse(Console.ReadLine()!);

    Console.Write("Local: ");
    string local = Console.ReadLine()!;

    Console.Write("Descrição: ");
    string descricao = Console.ReadLine()!;

    lista.Add(new Compromisso { Data = data, Hora = hora, Local = local, Descricao = descricao });
    Console.WriteLine("Compromisso adicionado.");
}

static void Editar(List<Compromisso> lista)
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

static void Excluir(List<Compromisso> lista)
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
```

Esse código oferece uma experiência funcional de CRUD via terminal, salvando todos os dados automaticamente ao sair.

Excelente! Vamos ao **Capítulo 5 — Testes e Validação**, onde mostraremos como executar a aplicação, testar todas as funcionalidades e verificar se os dados estão sendo corretamente armazenados no arquivo JSON.


### 5️⃣ Testes e Validação

Depois de implementar o menu e as funções de CRUD, é hora de testar a aplicação na prática e garantir que tudo esteja funcionando como esperado.


#### ▶️ Executando a aplicação

No terminal, dentro da pasta do projeto:

```bash
dotnet run
```

Você verá algo como:

```
=== MENU DE COMPROMISSOS ===
1. Listar
2. Adicionar
3. Editar
4. Excluir
0. Sair
Escolha uma opção:
```


#### ✅ Testando cada funcionalidade

##### 1. **Adicionar compromisso**

Escolha a opção `2`. Preencha com dados reais, como:

```
Data (dd/MM/yyyy): 15/05/2025
Hora (HH:mm): 14:00
Local: Sala 203
Descrição: Reunião com equipe de projeto
```

Você verá a mensagem:
`Compromisso adicionado.`


##### 2. **Listar compromissos**

Escolha a opção `1`. Deve aparecer:

```
1. 15/05/2025 às 14:00:00 - Sala 203 => Reunião com equipe de projeto
```


##### 3. **Editar compromisso**

Escolha a opção `3`. Selecione o número exibido anteriormente e altere os dados conforme solicitado.


##### 4. **Excluir compromisso**

Escolha a opção `4` e digite o número do compromisso para removê-lo. O sistema confirmará com:

```
Compromisso removido.
```


#### 📁 Verificando o arquivo JSON

Após sair da aplicação (`opção 0`), abra o arquivo `compromissos.json`, que estará na raiz da pasta do projeto. Você verá algo como:

```json
[
  {
    "Data": "2025-05-15T00:00:00",
    "Hora": "14:00:00",
    "Local": "Sala 203",
    "Descricao": "Reunião com equipe de projeto"
  }
]
```

✅ Isso confirma que os dados foram corretamente **serializados** e **gravados em disco**.


#### 🛠 Possíveis erros a testar

* Tentar editar ou excluir usando um número inválido.
* Digitar uma data ou hora em formato errado (como "15/13/2025" ou "99:99").

Esses testes mostram onde podemos melhorar a aplicação com **validações** — algo que pode ser trabalhado em uma etapa futura ou como desafio para os alunos.


No próximo capítulo, vamos abordar algumas **refatorações possíveis**, formas de **evoluir** a aplicação, e sugestões para desafios extras.


---

### 6️⃣ Conclusão e Próximos Passos


#### 📌 O que você construiu?

Neste projeto, você desenvolveu uma aplicação real do tipo CLI (Command Line Interface) utilizando **C#** e a plataforma **.NET**, com foco em um **CRUD completo** de compromissos. Foram aplicados conceitos fundamentais de programação:

* Criação e uso de **classes e objetos**.
* Manipulação de **listas genéricas**.
* Entrada e saída de dados com `Console`.
* **Persistência em disco** utilizando arquivos no formato **JSON**.
* Organização do código em funções reutilizáveis.

Esses fundamentos são a base de aplicações maiores, inclusive com interface gráfica ou web.


#### 🔁 O que pode ser melhorado?

Aqui estão algumas melhorias que você (ou seus alunos) podem explorar:

1. **Validação de dados de entrada**

   * Verificar se a data e hora estão em formato correto.
   * Impedir campos vazios para local e descrição.
   * Tratar erros com mensagens claras usando `try-catch`.

2. **Separação de responsabilidades**

   * Mover o código para classes separadas: `RepositorioCompromissos`, `Menu`, etc.
   * Aplicar princípios de boas práticas, como SOLID.

3. **Melhor experiência do usuário**

   * Mostrar a quantidade de compromissos.
   * Exibir os dados em formato amigável.
   * Confirmar antes de excluir ou editar.


#### 🚀 Caminhos para evolução

A aplicação pode ser expandida em várias direções:

| Caminho                  | Descrição                                                                       |
| ------------------------ | ------------------------------------------------------------------------------- |
| **Interface gráfica**    | Usar Windows Forms, WPF ou MAUI para criar uma versão visual.                   |
| **Banco de dados**       | Substituir o JSON por SQLite ou outro banco relacional usando Entity Framework. |
| **API Web**              | Criar uma API REST com ASP.NET para acessar os dados via navegador.             |
| **Testes automatizados** | Criar testes unitários com `xUnit` ou `NUnit` para garantir qualidade.          |
| **Deploy**               | Empacotar como aplicativo portável usando `dotnet publish`.                     |


#### 📚 Desafios para os alunos

* Implementar a ordenação por data e hora.
* Criar um filtro para exibir apenas compromissos futuros.
* Adicionar uma opção de busca por palavra-chave.
* Criar um sistema de login simples com usuários e senha (em memória).
* Gerar um relatório em TXT com os compromissos do mês.

Com isso, concluímos a construção da aplicação CLI de compromissos em C#. Ela é pequena no escopo, mas rica em aprendizado, e serve como ponto de partida para projetos maiores e mais complexos.

