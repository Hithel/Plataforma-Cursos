
namespace Domain.Entities;
    public class Instructor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }

        public ICollection<Curso> Cursos { get; set; }
        public ICollection<InstrucAsignatura> InstrucAsignaturas { get; set; }
        public ICollection<Asignatura> Asignaturas { get; set; }

    }
