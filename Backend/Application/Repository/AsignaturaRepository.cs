

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class AsignaturaRepository : GenericRepositoryEntity<Asignatura>, IAsignatura
    {
         private readonly ApiContext _context;

        public AsignaturaRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Asignatura>> GetAllAsync()
        {
            return await _context.Asignaturas
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<Asignatura> registros)> GetAllAsync(int pageIndez, int pageSize, int search)
        {
            var query = _context.Asignaturas as IQueryable<Asignatura>;

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

        public override async Task<Asignatura> GetByIdAsync(int id)
        {
            return await _context.Asignaturas
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
