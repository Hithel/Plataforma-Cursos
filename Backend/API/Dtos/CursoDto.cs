

using Domain.Entities;

namespace API.Dtos;
    public class CursoDto : BaseEntity
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Img { get; set; }
        public int IdInstructorFk { get; set; }
    }
