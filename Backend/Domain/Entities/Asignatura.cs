

namespace Domain.Entities;
    public class Asignatura 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<InstrucAsignatura> InstrucAsignaturas { get; set; }
        public ICollection<Instructor> Instructores { get; set; }
    }
