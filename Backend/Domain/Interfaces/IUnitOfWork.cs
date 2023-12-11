

namespace Domain.Interfaces;
    public interface  IUnitOfWork
    {
        IAsignatura Asignaturas { get; }
        ICalificacion Calificaciones { get; }
        ICurso Cursos { get; }
        IInstructor Instructor { get; }
        IRol Roles { get; }
        IUser Users { get; }

        Task<int> SaveAsync();
    }
