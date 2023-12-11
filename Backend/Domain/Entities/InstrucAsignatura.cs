

namespace Domain.Entities;
    public class InstrucAsignatura
    {
        public int IdInstructorFk { get; set; }
        public Instructor Instructor { get; set; }

        public int IdAsignaturaFK { get; set; }
        public Asignatura Asignatura { get; set;}
    }
