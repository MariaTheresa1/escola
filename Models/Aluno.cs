namespace escola.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public int TotalFaltas { get; set; }
        public Turma Turma { get; set; }

        public void consultarTodasOsAlunos()
        {

        }
        public void consultarAlunoPeloId()
        {

        }
        public void incluirAlunos()
        {

        }
        public void excluirAlunos()
        {

        }
        public void atualizarAlunos()
        {

        }
    }
}
