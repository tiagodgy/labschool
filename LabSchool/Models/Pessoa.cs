using System.ComponentModel.DataAnnotations;

namespace LabSchool.Models
{
    public class Pessoa
    {
        [Key]
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public long? Cpf { get; set; }
       
    }
}
