using LabSchool.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using System.Threading.Tasks;

namespace LabSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost]
        public async Task<ActionResult<Aluno?>> AdicionaAluno(Aluno aluno)
        {
            try
            {
                var result = await _alunoService.AdicionaAluno(aluno);
                return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
            }
            catch (ConflitoCpfException e)
            {
                return StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }


        }
        
        [HttpPut("{codigo}")]
        public async Task<ActionResult<Aluno?>> AlteraSituacao(int codigo, Aluno request)
        {
            try
            {
                var result = await _alunoService.AlteraSituacao(codigo, request);
                return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
            }
            catch (NaoEncontradoException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            
        }

        [HttpGet]
        public async Task<ActionResult<List<Aluno>>> BuscaAlunos(string? situacao)
        {
            try
            {
                var result = await _alunoService.BuscaAlunos(situacao);
                return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Aluno?>> BuscaUnicoAluno(int codigo)
        {
            try
            {
                var result = await _alunoService.BuscaUnicoAluno(codigo);
                return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
            }
            catch (NaoEncontradoException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult<Aluno?>> DeletaAluno(int codigo)
        {
            try
            {
                var result = await _alunoService.DeletaAluno(codigo);
                return new ObjectResult(null) { StatusCode = StatusCodes.Status204NoContent };
            }
            catch (NaoEncontradoException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }
    }
}
