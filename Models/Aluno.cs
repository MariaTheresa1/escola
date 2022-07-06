namespace escola.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public int? TotalFaltas { get; set; }
        public int TurmaId { get; set; }
        public virtual Turma Turma { internal get; set; }        
    }
}
