using Microsoft.EntityFrameworkCore;

namespace escola.Models
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options)
            : base(options)
        {
        }

        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turma>().ToTable("turma");
            modelBuilder.Entity<Aluno>()
                .HasOne(e => e.Turma) // 1 aluno tem 1 turma
                .WithMany(e => e.Alunos) //1 turma tem varios alunos
                .HasForeignKey(e => e.TurmaId); //campo da FK
            modelBuilder.Entity<Aluno>().ToTable("aluno");
        }
    }
}
