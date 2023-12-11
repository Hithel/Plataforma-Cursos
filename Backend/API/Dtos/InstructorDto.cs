

using Domain.Entities;

namespace API.Dtos;
    public class InstructorDto : BaseEntity
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
    }
