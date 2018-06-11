using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanDemo.Core;
using CleanDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanDemo.Web.Models
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly AgendaContext _context;
        private readonly DbSet<TEntity> _set;

        public Repository(AgendaContext context, DbSet<TEntity> set)
        {
            _context = context;
            _set = set;
        }
        public TEntity Get(int id) => _set.Find(id);

        public IEnumerable<TEntity> All => _set;

        public int Save(TEntity entity)
        {
            _set.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }
    }

    public class TurmaRepository : Repository<Turma>
    {
        public TurmaRepository(AgendaContext context) : base(context, context.Turmas)
        {
        }
    }

    public class CursoRepository : Repository<Curso>
    {
        public CursoRepository(AgendaContext context) : base(context, context.Cursos)
        {
        }
    }

    public class ProfessorRepository : Repository<Professor>
    {
        public ProfessorRepository(AgendaContext context) : base(context, context.Professores)
        {
        }
    }
}

