using EstacionamentoRhitmo.Enums;

namespace EstacionamentoRhitmo.Models
{
    public class IndicadorVagaModel
    {
        public int? Disponivel { get => Classificacao?.Sum(x => x.Disponivel); }
        public int? Total { get => Classificacao?.Sum(x => x.Total); }
        public ECapacidade Capacidade { get => CalcularCapacidade(); }
        public string CapacidadeDescricao { get => Capacidade.ToString(); }
        public List<ClassificacaoModel> Classificacao { get; set; }
        public List<OcupacaoModel> Ocupacao { get; set; }
        public ECapacidade CalcularCapacidade()
        {
            var total = Classificacao?.Sum(x => x.Total);
            var disponivel = Classificacao?.Sum(x => x.Disponivel);
            var reservado = Classificacao?.Sum(x => x.Reservado);

            if (disponivel.Equals(0))
                return ECapacidade.Indisponivel;

            if (disponivel.Equals(total)) 
                return ECapacidade.Total;

            return ECapacidade.Parcial;
        }
    }
}
