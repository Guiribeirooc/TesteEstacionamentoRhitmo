using EstacionamentoRhitmo.Interfaces;
using EstacionamentoRhitmo.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoRhitmo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacionamentoController : ControllerBase
    {
        private readonly IEstacionamentoRepository _estacionamentoRepository;

        public EstacionamentoController(IEstacionamentoRepository estacionamentoRepository)
        {
            _estacionamentoRepository = estacionamentoRepository;
        }

        [HttpGet("vagas-restantes")]
        public IActionResult GetVagasRestantes()
        {
            int vagasRestantes = _estacionamentoRepository.VagasRestantes();
            return Ok(vagasRestantes);
        }

        [HttpGet("vagas-totais")]
        public IActionResult GetVagasTotais()
        {
            int vagasTotais = _estacionamentoRepository.VagasTotais();
            return Ok(vagasTotais);
        }

        [HttpGet("estacionamento-cheio")]
        public IActionResult IsEstacionamentoCheio()
        {
            bool estacionamentoCheio = _estacionamentoRepository.EstacionamentoCheio();
            return Ok(estacionamentoCheio);
        }

        [HttpGet("estacionamento-vazio")]
        public IActionResult IsEstacionamentoVazio()
        {
            bool estacionamentoVazio = _estacionamentoRepository.EstacionamentoVazio();
            return Ok(estacionamentoVazio);
        }

        [HttpGet("vagas-moto-cheias")]
        public IActionResult VagasMotoCheias()
        {
            bool vagasMotoCheias = _estacionamentoRepository.VagasMotoCheias();
            return Ok(vagasMotoCheias);
        }

        [HttpGet("vagas-van-ocupadas")]
        public IActionResult VagasVanOcupadas()
        {
            int vagasVanOcupadas = _estacionamentoRepository.VagasVanOcupadas();
            return Ok(vagasVanOcupadas);
        }
    }
}