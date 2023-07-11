using EstacionamentoRhitmo.Enums;

namespace EstacionamentoRhitmo.Models
{
    public class ClassificacaoModel
    {
        public ClassificacaoModel(ETipoVaga tipoVaga, int total)
        {
            TipoVaga = tipoVaga;
            Total = total;
        }

        public ETipoVaga TipoVaga { get; set; }
        public string TipoVagaDescricao { get => TipoVaga.ToString(); }
        public int Total { get; set; }
        public int Reservado { get; set; }
        public int Disponivel { get => Total - Reservado; }
    }
}
