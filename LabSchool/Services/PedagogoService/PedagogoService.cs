using LabSchool.Data;

namespace LabSchool.Services.ProfessorService
{
    public class PedagogoService : IPedagogoService
    {
        private readonly DataContext _context;
        public PedagogoService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Pedagogo>> BuscaPedagogos()
        {
            var pedagogos = await _context.Pedagogos.ToListAsync();
            return pedagogos;
        }

    }
}
