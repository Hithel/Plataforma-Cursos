
namespace Domain.Entities;
    public class Curso
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Img { get; set; }
        public int IdInstructorFk { get; set; }
        public Instructor Instructor { get; set; }

        public ICollection<Calificacion> Calificaciones { get; set; }
        

    }
