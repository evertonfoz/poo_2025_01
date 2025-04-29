using System.Globalization;
using _20250428.Modelos;

// var compromisso = new Compromisso();

CultureInfo culturaBrasileira = new("pt-BR");

DateTime? dataCompromisso = null;
TimeSpan? horaCompromisso = null;

// DateTime.TryParseExact(
//     dataDigitada, "dd/MM/yyyy", 
//     culturaBrasileira, DateTimeStyles.None,
//     out dataCompromisso
//     );

while(dataCompromisso == null) {
    Console.Write("Informe a data para o Compromisso (dd/MM/yyyy): ");
    var dataDigitada = Console.ReadLine();
    
    try {
        dataCompromisso = DateTime.ParseExact(dataDigitada, "dd/MM/yyyy", culturaBrasileira);
    } catch (FormatException) {
        Console.WriteLine($"{dataDigitada} não é uma data válida");
    }
}

while(horaCompromisso == null) {
    Console.Write("Informe a hora para o Compromisso (HH:mm): ");
    var horaDigitada = Console.ReadLine();

    try
    {
        horaCompromisso = TimeSpan.ParseExact(horaDigitada, "hh\\:mm", culturaBrasileira);
    }
    catch (FormatException)
    {
        Console.WriteLine($"{horaDigitada} não é uma hora válida");
    }
}

try {
    var compromisso = new Compromisso((DateTime)dataCompromisso, 
        (TimeSpan)horaCompromisso, "Aula", "UTFPR");
    Console.WriteLine("Compromisso registrado");
    Console.WriteLine(compromisso);

    compromisso.RegistrarData(DateTime.Now);
    Console.WriteLine(compromisso);

} catch (ArgumentException e) {
    Console.WriteLine(e.Message);
}
// try {
//     compromisso.RegistrarData((DateTime)dataCompromisso);
// } catch (ArgumentException e) {
//     Console.WriteLine(e.Message);
// }

// try {
//     compromisso.RegistrarHora((TimeSpan) horaCompromisso);
// } catch (ArgumentException e) {
//     Console.WriteLine(e.Message);
// }
