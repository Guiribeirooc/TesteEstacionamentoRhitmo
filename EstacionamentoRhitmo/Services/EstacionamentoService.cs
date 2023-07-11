using EstacionamentoRhitmo.Enums;
using EstacionamentoRhitmo.Interfaces;
using EstacionamentoRhitmo.Models;
using EstacionamentoRhitmo.Repositories;

namespace EstacionamentoRhitmo.Services
{
    public class EstacionamentoService : IEstacionamentoService
    {
        private readonly static IEstacionamentoRepository _repository = new EstacionamentoRepository();

        public ResponseModel Reservar(ETipoVeiculo tipoVeiculo)
        {
            if(!Enum.IsDefined(typeof(ETipoVeiculo), tipoVeiculo))
                return new ResponseModel(false, null, "Tipo do veículo não corresponde.");

            var vagas = _repository.ObterIndicadores();

            if (vagas.Disponivel.Equals(0))
                return new ResponseModel(false, null, "Nenhuma vaga disponível no momento.");

            if (tipoVeiculo.Equals(ETipoVeiculo.Moto))
                if (TratativaReservaMoto(vagas))
                    return new ResponseModel(true, null, "Reserva realizada com sucesso.");

            if (tipoVeiculo.Equals(ETipoVeiculo.Carro))
                if (TratativaReservaCarro(vagas))
                    return new ResponseModel(true, null, "Reserva realizada com sucesso.");

            if (tipoVeiculo.Equals(ETipoVeiculo.Van))
                if (TratativaReservaVan(vagas))
                    return new ResponseModel(true, null, "Reserva realizada com sucesso.");

            return new ResponseModel(true, null, "Reserva não foi realizada.");
        }

        private bool TratativaReservaMoto(IndicadorVagaModel indicador)
        {
            if(indicador.Classificacao.Where(x => x.TipoVaga.Equals(ETipoVaga.Moto)).Sum(x => x.Disponivel) > 0)
            {
                _repository.Reservar(ETipoVeiculo.Moto, ETipoVaga.Moto, 1);
                return true;
            }

            if (indicador.Classificacao.Where(x => x.TipoVaga.Equals(ETipoVaga.Moto)).Sum(x => x.Disponivel).Equals(0)
                && indicador.Classificacao.Where(x => x.TipoVaga.Equals(ETipoVaga.Carro)).Sum(x => x.Disponivel) >0) 
            {
                _repository.Reservar(ETipoVeiculo.Moto, ETipoVaga.Carro, 1);
                return true;
            }

            if (indicador.Classificacao.Where(x => x.TipoVaga.Equals(ETipoVaga.Moto)).Sum(x => x.Disponivel).Equals(0)
                && indicador.Classificacao.Where(x => x.TipoVaga.Equals(ETipoVaga.Carro)).Sum(x => x.Disponivel).Equals(0)
                && indicador.Classificacao.Where(x => x.TipoVaga.Equals(ETipoVaga.Grande)).Sum(x => x.Disponivel) > 0)
            {
                _repository.Reservar(ETipoVeiculo.Moto, ETipoVaga.Grande, 1);
                return true;
            }

            return false;
        }

        private bool TratativaReservaCarro(IndicadorVagaModel indicador)
        {
            if (indicador.Classificacao.Where(x => x.TipoVaga.Equals(ETipoVaga.Carro)).Sum(x => x.Disponivel) > 0)
            {
                _repository.Reservar(ETipoVeiculo.Carro, ETipoVaga.Carro, 1);
                return true;
            }

            if (indicador.Classificacao.Where(x => x.TipoVaga.Equals(ETipoVaga.Carro)).Sum(x => x.Disponivel).Equals(0)
                && indicador.Classificacao.Where(x => x.TipoVaga.Equals(ETipoVaga.Grande)).Sum(x => x.Disponivel) > 0)
            {
                _repository.Reservar(ETipoVeiculo.Carro, ETipoVaga.Grande, 1);
                return true;
            }

            return false;
        }

        private bool TratativaReservaVan(IndicadorVagaModel indicador)
        {
            if (indicador.Classificacao.Where(x => x.TipoVaga.Equals(ETipoVaga.Grande)).Sum(x => x.Disponivel) > 0)
            {
                _repository.Reservar(ETipoVeiculo.Van, ETipoVaga.Grande, 1);
                return true;
            }

            if (indicador.Classificacao.Where(x => x.TipoVaga.Equals(ETipoVaga.Grande)).Sum(x => x.Disponivel).Equals(0)
                && indicador.Classificacao.Where(x => x.TipoVaga.Equals(ETipoVaga.Carro)).Sum(x => x.Disponivel) >= 3)
            {
                _repository.Reservar(ETipoVeiculo.Van, ETipoVaga.Carro, 3);
                return true;
            }

            return false;
        }
    }
}
