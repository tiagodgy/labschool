using LabSchool.Data;

namespace LabSchool.Services.PedagogoService
{
    public class ProfessorService : IProfessorService
    {
        private readonly DataContext _context;
        public ProfessorService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Professor>> BuscaProfessores()
        {
            var professores = await _context.Professores.ToListAsync();
            return professores;
        }
    }
}
