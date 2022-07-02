using Microsoft.EntityFrameworkCore;

namespace escola.Models
{
    public class TurmaContext : DbContext
    {
        public TurmaContext(DbContextOptions<AlunoContext> options)
            : base(options)
        {
        }

        public DbSet<Turma> Turmas { get; set; }
    }
}
