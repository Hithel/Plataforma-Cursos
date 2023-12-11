

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class CursoRepository : GenericRepositoryEntity<Curso>, ICurso
    {
         private readonly ApiContext _context;

        public CursoRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Curso>> GetAllAsync()
        {
            return await _context.Cursos
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<Curso> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
        {
            var query = _context.Cursos as IQueryable<Curso>;

            if (!string.IsNullOrEmpty(search.ToString()))
            {
                query = query.Where(p => p.Id.Equals(search));
            }

            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Skip((pageIndez - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);
        }

        public override async Task<Curso> GetByIdAsync(int id)
        {
            return await _context.Cursos
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }

