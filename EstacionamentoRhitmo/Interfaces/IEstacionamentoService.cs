using EstacionamentoRhitmo.Enums;
using EstacionamentoRhitmo.Models;

namespace EstacionamentoRhitmo.Interfaces
{
    public interface IEstacionamentoService
    {
        ResponseModel Reservar(ETipoVeiculo tipoVeiculo);
    }
}
