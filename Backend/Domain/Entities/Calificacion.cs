

namespace Domain.Entities;
    public class Calificacion
    {
         public int IdUserFk { get; set; }
         public User User { get; set; }

         public int IdCursoFK { get; set; }
         public Curso Curso { get; set; }

         public double Puntaje { get; set; }
         public string Descripcion { get; set; } 
    }
