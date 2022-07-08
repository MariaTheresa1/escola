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
            modelBuilder.Entity<Aluno>().ToTable("aluno");
        }
    }
}
