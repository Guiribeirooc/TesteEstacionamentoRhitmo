namespace EstacionamentoRhitmo.Models
{
    public abstract class Veiculo
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
    }
    public class Moto : Veiculo { }
    public class Carro : Veiculo { }
    public class Van : Veiculo { }
}