using System.ComponentModel.DataAnnotations.Schema;

namespace escola.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Column ("Data_Nascimento")]
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        [Column("Total_Faltas")]
        public int TotalFaltas { get; set; }
        [Column("Turma_Id")]
        public int TurmaId { get; set; }
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
