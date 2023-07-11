using EstacionamentoRhitmo.Enums;
using EstacionamentoRhitmo.Models;

namespace EstacionamentoRhitmo.Repositories
{
    public class EstacionamentoRepository
    {
        private static IndicadorVagaModel _indicadorVaga = new IndicadorVagaModel();

        public EstacionamentoRepository()
        {
            _indicadorVaga.Classificacao = new List<ClassificacaoModel>();
            _indicadorVaga.Classificacao.Add(new ClassificacaoModel(ETipoVaga.Moto, 10));
            _indicadorVaga.Classificacao.Add(new ClassificacaoModel(ETipoVaga.Carro, 10));
            _indicadorVaga.Classificacao.Add(new ClassificacaoModel(ETipoVaga.Grande, 10));
            _indicadorVaga.Ocupacao = new List<OcupacaoModel>();
        }

        public void AdicionarVaga(ClassificacaoModel classificacao)
        {
            _indicadorVaga.Classificacao.Add(classificacao);
        }

        public IndicadorVagaModel ObterIndicadores()
        {
            return _indicadorVaga;
        }

        public void Reservar(ETipoVeiculo tipoVeiculo, ETipoVaga tipoVaga, int quantidade)
        {
            _indicadorVaga.Ocupacao.Add(new OcupacaoModel(DateTime.Now, tipoVeiculo, tipoVaga, quantidade));
            _indicadorVaga.Classificacao.Where(x => x.TipoVaga.Equals(tipoVaga)).FirstOrDefault().Reservado += quantidade;
        }
    }
}