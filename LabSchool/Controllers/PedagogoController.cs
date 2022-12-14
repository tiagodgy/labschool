using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedagogoController : ControllerBase
    {
        private readonly IPedagogoService _pedagogoService;

        public PedagogoController(IPedagogoService pedagogoService)
        {
            _pedagogoService = pedagogoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _pedagogoService.BuscaPedagogos();
                return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
