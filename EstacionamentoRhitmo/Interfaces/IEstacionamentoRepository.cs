namespace EstacionamentoRhitmo.Interfaces
{
    public interface IEstacionamentoRepository
    {
        int VagasRestantes();
        int VagasTotais();
        bool EstacionamentoCheio();
        bool EstacionamentoVazio();
        bool VagasMotoCheias();
        int VagasVanOcupadas();
    }
}