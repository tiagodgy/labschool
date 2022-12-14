using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Professor>>> BuscaProfessores()
        {
            try
            {
                var result = await _professorService.BuscaProfessores();
                return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
