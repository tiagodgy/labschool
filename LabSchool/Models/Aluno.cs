
namespace LabSchool.Models
{
    public class Aluno : Pessoa
    {
        public string? Situacao { get; set; }
        public float? Nota { get; set; }
        public int? Atendimentos { get; set; } = 0; 
    }
}
