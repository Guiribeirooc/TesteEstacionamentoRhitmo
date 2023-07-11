using EstacionamentoRhitmo.Enums;

namespace EstacionamentoRhitmo.Models
{
    public class OcupacaoModel
    {
        public OcupacaoModel(DateTime dataReserva, ETipoVeiculo tipoVeiculo, ETipoVaga tipoVaga, int quantidade) 
        {
            DataReserva = dataReserva;
            TipoVeiculo = tipoVeiculo;
            TipoVaga = tipoVaga;
            Quantidade = quantidade;
        }

        public DateTime DataReserva { get;set; }
        public ETipoVeiculo TipoVeiculo { get;set;}
        public string TipoVeiculoDescricao { get => TipoVeiculo.ToString(); }
        public ETipoVaga TipoVaga { get;set; }
        public string TipoVagaDescricao { get => TipoVaga.ToString(); }
        public int Quantidade { get; set; }
    }
}
