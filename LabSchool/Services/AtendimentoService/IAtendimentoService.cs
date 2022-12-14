namespace LabSchool.Services.AtendimentoService
{
    public interface IAtendimentoService
    {
        Task<Atendimento?> RealizarAtendimento(AtendimentoData atendimentoData);
    }
}
