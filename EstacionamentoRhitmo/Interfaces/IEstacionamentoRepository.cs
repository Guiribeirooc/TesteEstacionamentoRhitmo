using EstacionamentoRhitmo.Enums;
using EstacionamentoRhitmo.Models;

namespace EstacionamentoRhitmo.Interfaces
{
    public interface IEstacionamentoRepository
    {
        IndicadorVagaModel ObterIndicadores();
        void Reservar(ETipoVeiculo tipoVeiculo, ETipoVaga tipoVaga, int quantidade);
    }
}
