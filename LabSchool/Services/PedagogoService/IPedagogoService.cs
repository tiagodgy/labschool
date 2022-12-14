namespace LabSchool.Services.ProfessorService
{
    public interface IPedagogoService
    {
        Task<List<Pedagogo>> BuscaPedagogos();
    }
}
