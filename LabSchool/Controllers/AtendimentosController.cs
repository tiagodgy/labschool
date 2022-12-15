using LabSchool.Exceptions;
using LabSchool.ViewModels;

namespace LabSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentosController : ControllerBase
    {
        private readonly IAtendimentoService _atendimentoService;

        public AtendimentosController(IAtendimentoService atendimentoService)
        {
            _atendimentoService = atendimentoService;
        }

        [HttpPut]
        public async Task<ActionResult<Atendimento?>> RealizarAtendimento(AtendimentoData atendimentoData)
        {
            try
            {
                var result = await _atendimentoService.RealizarAtendimento(atendimentoData);
                return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
            }
            catch (NaoEncontradoException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

    }
}
