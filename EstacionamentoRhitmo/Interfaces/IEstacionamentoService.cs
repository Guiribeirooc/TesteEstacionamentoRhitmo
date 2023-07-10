using EstacionamentoRhitmo.Models;

namespace EstacionamentoRhitmo.Interfaces
{
    public interface IEstacionamentoService
    {
        void EstacionarVeiculo(Veiculo veiculo);
        void RetirarVeiculo(string placa);
        List<Veiculo> ListarVeiculosEstacionados();
    }
}