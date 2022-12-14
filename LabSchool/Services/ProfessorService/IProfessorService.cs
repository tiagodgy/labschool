namespace LabSchool.Services.PedagogoService
{
    public interface IProfessorService
    {
        Task<List<Professor>> BuscaProfessores();
    }
}
