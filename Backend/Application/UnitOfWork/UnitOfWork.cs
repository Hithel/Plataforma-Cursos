using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        
        private readonly ApiContext _context;


        private AsignaturaRepository _asignatura;
        private CalificacionRepository _calificacion;
        private CursoRepository _curso;
        private InstructorRepository _instructor;
        private UserRepository _users;
        private RolRepository _roles; 

     public UnitOfWork (ApiContext context)
        {
            _context = context;
        }
        
        public IAsignatura Asignaturas
        {
            get
            {
                if (_asignatura == null)
                {
                    _asignatura = new AsignaturaRepository(_context);
                }
                return _asignatura;
            }
        }

        public ICalificacion Calificaciones
        {
            get
            {
                if (_calificacion == null)
                {
                    _calificacion = new CalificacionRepository(_context);
                }
                return _calificacion;
            }
        }

        public ICurso Cursos
        {
            get
            {
                if (_curso == null)
                {
                    _curso = new CursoRepository(_context);
                }
                return _curso;
            }
        }
        public IInstructor Instructor
        {
            get
            {
                if (_instructor == null)
                {
                    _instructor = new InstructorRepository(_context);
                }
                return _instructor;
            }
        }
        

        public IUser Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }

        public IRol Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }





    }
}
