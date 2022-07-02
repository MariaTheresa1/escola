using Microsoft.EntityFrameworkCore;

namespace escola.Models
{
    public class AlunoContext : DbContext
    {
        public AlunoContext(DbContextOptions<AlunoContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
