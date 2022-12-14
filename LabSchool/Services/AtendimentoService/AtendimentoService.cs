using LabSchool.Data;
using LabSchool.Exceptions;

namespace LabSchool.Services.AtendimentoService
{
    public class AtendimentoService: IAtendimentoService
    {
        private readonly DataContext _context;
        public AtendimentoService(DataContext context)
        {
            _context = context;
        }

        public async Task<Atendimento?> RealizarAtendimento(AtendimentoData atendimentoData)
        {
            var aluno = await _context.Alunos.FindAsync(atendimentoData.CodigoAluno);
            var pedagogo = await _context.Pedagogos.FindAsync(atendimentoData.CodigoPedagogo);
            if(aluno is null)
                throw new NaoEncontradoException("Aluno não encontrado");
            if (pedagogo is null)
                throw new NaoEncontradoException("Pedagogo não encontrado");
            aluno.Situacao = "ATENDIMENTO_PEDAGOGICO";
            aluno.Atendimentos = aluno.Atendimentos + 1;
            pedagogo.Atendimentos = pedagogo.Atendimentos + 1;
            await _context.SaveChangesAsync();
            return new Atendimento
            {
                Aluno = aluno,
                Pedagogo = pedagogo
            };
        }
    }
}
