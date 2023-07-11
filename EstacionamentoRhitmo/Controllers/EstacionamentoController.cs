using EstacionamentoRhitmo.Enums;
using EstacionamentoRhitmo.Models;
using EstacionamentoRhitmo.Repositories;
using EstacionamentoRhitmo.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoRhitmo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstacionamentoController : ControllerBase
    {
        private static EstacionamentoRepository _repository = new EstacionamentoRepository();
        private static EstacionamentoService _service = new EstacionamentoService();

        [HttpGet("obter-vagas")]
        public IActionResult ObterVagas()
        {
            var result  = _repository.ObterIndicadores();
            return Ok(result);
        }

        [HttpPost("reservar-vagas")]
        public IActionResult ReservarVagas([FromBody] ReservarRequest request)
        {
            var result = _service.Reservar(request.TipoVeiculo);
            return Ok(result);
        }
    }
}