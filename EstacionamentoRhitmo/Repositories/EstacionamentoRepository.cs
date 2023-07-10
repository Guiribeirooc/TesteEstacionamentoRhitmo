using EstacionamentoRhitmo.Interfaces;

namespace EstacionamentoRhitmo.Repositories
{
    public class EstacionamentoRepository : IEstacionamentoRepository
    {
        private int vagasMotoLivres;
        private int vagasCarroLivres;
        private int vagasGrandeLivres;

        public EstacionamentoRepository(int vagasMoto, int vagasCarro, int vagasGrande)
        {
            vagasMotoLivres = vagasMoto;
            vagasCarroLivres = vagasCarro;
            vagasGrandeLivres = vagasGrande;
        }

        public int VagasRestantes()
        {
            return vagasMotoLivres + vagasCarroLivres + vagasGrandeLivres;
        }

        public int VagasTotais()
        {
            // Supondo que o total de vagas é a soma de todas as vagas para cada tipo de veículo
            return vagasMotoLivres + vagasCarroLivres + vagasGrandeLivres;
        }

        public bool EstacionamentoCheio()
        {
            return vagasMotoLivres == 0 && vagasCarroLivres == 0 && vagasGrandeLivres == 0;
        }

        public bool EstacionamentoVazio()
        {
            return vagasMotoLivres == VagasTotais() && vagasCarroLivres == VagasTotais() && vagasGrandeLivres == VagasTotais();
        }

        public bool VagasMotoCheias()
        {
            return vagasMotoLivres == 0;
        }

        public int VagasVanOcupadas()
        {
            // Supondo que uma van ocupa três vagas de carro ou uma vaga grande
            return (VagasTotais() - VagasRestantes()) / 3;
        }
    }
}
