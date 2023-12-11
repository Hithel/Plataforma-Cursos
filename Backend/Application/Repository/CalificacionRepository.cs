

using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
    public class CalificacionRepository : GenericRepositoryEntity<Calificacion>, ICalificacion
    {
         private readonly ApiContext _context;

        public CalificacionRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Calificacion>> GetAllAsync()
        {
            return await _context.Calificaciones
                .ToListAsync();
        }

        public  async Task<(int totalRegistros, IEnumerable<Calificacion> registros)> GetAllAsync(int pageIndez, int pageSize,(int IdUserFk, int IdCursoFK) search)
        {
            var query = _context.Calificaciones as IQueryable<Calificacion>;

            if (!string.IsNullOrEmpty(search.ToString()))
            {
                query = query.Where(p => p.IdUserFk == search.IdUserFk && p.IdCursoFK == search.IdCursoFK);
            }

            var totalRegistros = await query.CountAsync();
            var registros = await query
            .OrderBy(p => p.IdUserFk).ThenBy(p => p.IdUserFk)
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            return (totalRegistros, registros);
        }

        // public override async Task<Calificacion> GetByIdAsync(int id)
        // {
        //     return await _context.Calificaciones
        //     .FirstOrDefaultAsync(p => p.Id == id);
        // }
    }
