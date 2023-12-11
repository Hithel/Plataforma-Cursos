namespace API.Dtos;
    public class CalificacionDto
    {
        public int IdUserFk { get; set; }

         public int IdCursoFK { get; set; }

         public double Puntaje { get; set; }
         public string Descripcion { get; set; } 
    }
