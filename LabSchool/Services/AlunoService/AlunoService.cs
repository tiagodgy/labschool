using LabSchool.Data;
using LabSchool.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LabSchool.Services.AlunoService
{
    public class AlunoService : IAlunoService
    {
        private readonly DataContext _context;

        public AlunoService(DataContext context)
        {
            _context = context;
        }
        public async Task<Aluno?> AdicionaAluno(Aluno aluno)
        {
            var cpf = _context.Alunos.Any(x => x.Cpf == aluno.Cpf);
            if (!cpf)
            {
                if (aluno.Situacao == "ATIVO" || aluno.Situacao == "IRREGULAR" || aluno.Situacao == "ATENDIMENTO_PEDAGOGICO" || aluno.Situacao == "INATIVO")
                {
                    if (aluno.Nota >= 0 && aluno.Nota <= 10)
                    {
                        if (aluno.Nome != null)
                        {
                            if (aluno.Telefone != null)
                            {
                                if(aluno.DataNascimento != null)
                                {
                                    if (aluno.Cpf != null) {
                                        _context.Alunos.Add(aluno);
                                        await _context.SaveChangesAsync();
                                        return (aluno);
                                    }
                                    else
                                    {
                                        throw new Exception("CPF não pode ser nulo");
                                    } 
                                }
                                else
                                {
                                    throw new Exception("Data de nascimento não pode ser nula");
                                }

                            }
                            else
                            {
                                throw new Exception("Telefone não pode ser nulo");
                            }
                        }
                        else
                        {
                            throw new Exception("Nome não pode ser nulo");
                        }
                    }
                    else
                    {
                        throw new Exception("Nota deve ser entre 0 e 10");
                    }


                }
                else
                {
                    throw new Exception("Situação deve ser ATIVO, IRREGULAR, ATENDIMENTO_PEDAGOGICO ou INATIVO");
                }
            }
            else
            {
                throw new ConflitoCpfException("CPF já cadastrado");
            }

        }

        public async Task<Aluno?> AlteraSituacao(int codigo, Aluno request)
        {
            var aluno = await _context.Alunos.FindAsync(codigo);
           if(aluno is null)
                throw new NaoEncontradoException("Aluno não encontrado");
            if (request.Situacao == "ATIVO" || request.Situacao == "IRREGULAR" || request.Situacao == "ATENDIMENTO_PEDAGOGICO" || request.Situacao == "INATIVO")
            {
                
                aluno.Situacao = request.Situacao;
                await _context.SaveChangesAsync();
                return aluno;
            }
            else
            {
                throw new Exception("Situação deve ser ATIVO, IRREGULAR, ATENDIMENTO_PEDAGOGICO ou INATIVO");
            }
        }

        public Task<List<Aluno>> BuscaAlunos(string? situacao)
        {
            if(situacao == "ATIVO" || situacao == "IRREGULAR" || situacao == "ATENDIMENTO_PEDAGOGICO" || situacao == "INATIVO" || situacao is null)
            {
                if (situacao is null)
                    return _context.Alunos.ToListAsync();
                else
                    return _context.Alunos.Where(x => x.Situacao == situacao).ToListAsync();

            }
            else
            {
                throw new Exception("Situação deve ser ATIVO, IRREGULAR, ATENDIMENTO_PEDAGOGICO, INATIVO ou vazia");
            }
            
            
        }

        public async Task<Aluno?> BuscaUnicoAluno(int codigo)
        {
            var aluno = await _context.Alunos.FindAsync(codigo);
            if (aluno is null)
                throw new NaoEncontradoException("Aluno não encontrado");
            return aluno;
        }

        public async Task<Aluno?> DeletaAluno(int codigo)
        {
            var aluno = await _context.Alunos.FindAsync(codigo);
            if(aluno is null)
                throw new NaoEncontradoException("Aluno não encontrado");
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
