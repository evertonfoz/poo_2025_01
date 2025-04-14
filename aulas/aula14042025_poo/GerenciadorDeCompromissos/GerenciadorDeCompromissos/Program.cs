using ConsoleApp.Modelos;

Compromisso compromisso = new();

Console.WriteLine("Vamos registrar um compromisso");

Console.Write("Digite a data do compromisso (dd/MM/aaaa): ");
// var dataDigitada = Console.ReadLine();

while (true) {
    try {
        compromisso.Data = Console.ReadLine();
        break;
    } catch (Exception e) {
        Console.Write($"Erro: {e.Message}\nDigite uma nova data: ");
    }
}
// Console.Write("Digite a hora do compromisso (HH:mm): ");
// var horaDigitada = Console.ReadLine();

// TimeSpan horaCompromisso;

// while(!TimeSpan.TryParse(horaDigitada, out horaCompromisso)) {
//     Console.WriteLine("HORA INVÁLIDA. \nDigite a hora do compromisso (HH:mm): ");
//     horaDigitada = Console.ReadLine();
// }

// Console.Write("Digite a DESCRIÇÃO para o compromisso: ");
// var descricao = Console.ReadLine();

// Console.Write("Digite o LOCAL para o compromisso: ");
// var local = Console.ReadLine();

// DateTime dataEHoraParaCompromisso = dataCompromisso.Add(horaCompromisso); 

// Console.WriteLine("Data: " + dataCompromisso.Date.ToShortDateString());
// Console.WriteLine($"Hora: {horaCompromisso}");
// Console.WriteLine($"Descrição: {descricao}");
// Console.WriteLine($"Local: {local}");

// Console.WriteLine($"Data e Hora: {dataEHoraParaCompromisso}");


// // Compromisso compromisso = new Compromisso();
// // var compromisso = new Compromisso();



// // Compromisso compromisso = new();
// // compromisso.Data = DateTime.Now.Date;
// // Console.WriteLine(compromisso.Data);
// // Console.WriteLine(compromisso.DataBR());

// // compromisso.RegistrarData(DateTime.Now.Date);

// // Console.Write(compromisso.ObterData());

