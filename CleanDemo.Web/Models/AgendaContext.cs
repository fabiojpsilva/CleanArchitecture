using CleanDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanDemo.Web.Models
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options)
            : base(options)
        { 
            
        }

        public DbSet<Professor> Professores { get; set; }

        public DbSet<Turma> Turmas { get; set; }

        public DbSet<Curso> Cursos { get; set; }
    }
}
