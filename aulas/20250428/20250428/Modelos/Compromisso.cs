using System.Reflection.Metadata;

namespace _20250428.Modelos;

public class Compromisso
{
    private DateTime _data;
    private TimeSpan _hora;
     private DateTime _dataMinima = DateTime.Today.AddDays(1);
    private DateTime _dataMaxima = DateTime.Today.AddDays(30);
     private TimeSpan _horaMinima = new (8, 0, 0);
    private TimeSpan _horaMaxima = new (17, 30, 0);


    public DateTime Data { get {
        return _data;
    }  }

    public TimeSpan Hora { get {
        return _hora;
    } }

    public string Descricao { get; set; }
    public string Local { get; set; }
    public List<string> ErrosDeValidacao = [];

    public Compromisso(DateTime dataCompromisso, TimeSpan horaCompromisso,
        string descricao, string local) {
            Descricao = descricao;
            Local = local;
            _data = dataCompromisso;
            _hora =horaCompromisso;

            if (!ValidarCompromisso()) {
                throw new ArgumentException(string.Join("\n", ErrosDeValidacao));
            }

            // if (ValidarCompromisso(dataCompromisso, horaCompromisso)) {
            //     RegistrarData(dataCompromisso);
            //     RegistrarHora(horaCompromisso);
            // } else {
            //     throw new ArgumentException($"Data e/ou Hora informadas, "+
            //      $"inválidas.\nData mínima: {_dataMinima}\nData máxima: "+
            //      $"{_dataMaxima}\nHora mínima {_horaMinima}\nHora máxima: {_horaMaxima}");
            // }
    }
    public void  RegistrarData (DateTime data) {
        if (data < _dataMinima) {
            throw new ArgumentException($"A data {data.ToString("dd/MM/yyyy")} precisa ser no mínimo {_dataMinima.ToString("dd/MM/yyyy")}\n");
        }
        if (data > _dataMaxima) {
            throw new ArgumentException($"A data {data.ToString("dd/MM/yyyy")} precisa ser no máximo {_dataMaxima.ToString("dd/MM/yyyy")}\n");
        }

        _data = data;
    }

    public void RegistrarHora(TimeSpan hora) {
        if (hora < _horaMinima) {
            throw new ArgumentException($"Hora {hora} deve ser no mínimo {_horaMinima}");
        }
        if (hora > _horaMaxima) {
            throw new ArgumentException($"Hora {hora} deve ser no máximo {_horaMaxima}");
        }

        _hora = hora;
    }

    public bool ValidarCompromisso() {
        if (_data < _dataMinima ) {
             ErrosDeValidacao.Add($"A data {_data.ToString("dd/MM/yyyy")} precisa ser no mínimo {_dataMinima.ToString("dd/MM/yyyy")}");
        }
        if (_data > _dataMaxima ) {
             ErrosDeValidacao.Add($"A data {_data.ToString("dd/MM/yyyy")} precisa ser no máximo {_dataMaxima.ToString("dd/MM/yyyy")}");
        }
        if (_hora < _horaMinima ) {
             ErrosDeValidacao.Add($"A hora {_hora} precisa ser no mínimo {_horaMinima}");
        }
        if (_hora > _horaMaxima ) {
             ErrosDeValidacao.Add($"A hora {_hora} precisa ser no máximo {_horaMaxima}");
        }

        return ErrosDeValidacao.Count == 0;


        // bool dataValida = false;
        // bool horaValida = false;

        // if (data >= _dataMinima && data <= _dataMaxima) {
        //      dataValida = true;
        // }
        
        // if (hora >= _horaMinima && hora <= _horaMaxima) {
        //     horaValida = true;
        // }

        // return (dataValida && horaValida);
    }

    public override string ToString()
    {
        return $"Data: {_data.ToString("dd/MM/yyyy")}\nHora: {_hora}\nDescrição: {Descricao}\nLocal: {Local}";
    }
}
