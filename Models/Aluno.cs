namespace escola.Models
{
    public class Aluno
    {
        public int id;
        public string nome;
        public DateTime dataNascimento = new DateTime();
        public char sexo;
        public Turma turma;
        public int totalFaltas;

        public Aluno(int id, string nome, DateTime dataNascimento, char sexo, Turma turma, int totalFaltas)
        {
            this.id = id;
            this.nome = nome;
            this.dataNascimento = dataNascimento;
            this.sexo = sexo;
            this.turma = turma;
            this.totalFaltas = totalFaltas;
        }
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
