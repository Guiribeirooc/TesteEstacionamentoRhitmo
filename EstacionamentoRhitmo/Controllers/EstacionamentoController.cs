using EstacionamentoRhitmo.Interfaces;
using EstacionamentoRhitmo.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoRhitmo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacionamentoController : ControllerBase
    {
        private readonly IEstacionamentoService _estacionamentoService;

        public EstacionamentoController(IEstacionamentoService estacionamentoService)
        {
            _estacionamentoService = estacionamentoService;
        }

        [HttpGet("vagas-restantes")]
        public ActionResult<int> GetVagasRestantes()
        {
            int vagas = _estacionamentoService.CalcularVagasRestantes();
            return Ok(vagas);
        }

        [HttpGet("vagas-totais")]
        public ActionResult<int> GetVagasTotais()
        {
            int vagas = _estacionamentoService.CalcularVagasTotais();
            return Ok(vagas);
        }

        [HttpGet("estacionamento-cheio")]
        public ActionResult<bool> GetEstacionamentoCheio()
        {
            bool cheio = _estacionamentoService.VerificarEstacionamentoCheio();
            return Ok(cheio);
        }

        [HttpGet("estacionamento-vazio")]
        public ActionResult<bool> GetEstacionamentoVazio()
        {
            bool vazio = _estacionamentoService.VerificarEstacionamentoVazio();
            return Ok(vazio);
        }

        [HttpGet("vagas-moto-cheias")]
        public ActionResult<bool> GetVagasMotoCheias()
        {
            bool cheias = _estacionamentoService.VerificarVagasMotoCheias();
            return Ok(cheias);
        }

        [HttpGet("vagas-van-ocupadas")]
        public ActionResult<int> GetVagasVanOcupadas()
        {
            int vagas = _estacionamentoService.ContarVagasVanOcupadas();
            return Ok(vagas);
        }

    }
}
