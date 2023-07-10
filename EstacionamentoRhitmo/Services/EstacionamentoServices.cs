using EstacionamentoRhitmo.Interfaces;
using EstacionamentoRhitmo.Models;

namespace EstacionamentoRhitmo.Services
{
    public class EstacionamentoService : IEstacionamentoService
    {
        private List<Veiculo> veiculosEstacionados;

        public EstacionamentoService()
        {
            veiculosEstacionados = new List<Veiculo>();
        }

        public void EstacionarVeiculo(Veiculo veiculo)
        {
            veiculosEstacionados.Add(veiculo);
            Console.WriteLine("Veículo estacionado com sucesso.");
        }

        public void RetirarVeiculo(string placa)
        {
            Veiculo veiculo = veiculosEstacionados.FirstOrDefault(v => v.Placa == placa);

            if (veiculo != null)
            {
                veiculosEstacionados.Remove(veiculo);
                Console.WriteLine("Veículo retirado com sucesso.");
            }
            else
            {
                Console.WriteLine("Veículo não encontrado no estacionamento.");
            }
        }

        public List<Veiculo> ListarVeiculosEstacionados()
        {
            return veiculosEstacionados;
        }
    }
}
