namespace LabSchool.Services.AlunoService
{
    public interface IAlunoService
    {
        Task<Aluno?> AdicionaAluno(Aluno aluno);
        Task<Aluno?> AlteraSituacao(int codigo, Aluno request);
        Task<List<Aluno>> BuscaAlunos(string? situacao);
        Task<Aluno?> BuscaUnicoAluno(int codigo);
        Task<Aluno?> DeletaAluno(int codigo);
    }
}
