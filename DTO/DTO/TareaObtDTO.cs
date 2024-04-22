
using System.ComponentModel.DataAnnotations;

namespace DTO.DTO
{
    public class TareaObtDTO
    {

        public string codTarea { get; set; }
       
        public DateTime fechaAdicion { get; set; }

        public string descripcion { get; set; }

        public string nombrePersonaAsignada { get; set; }

        public string nombreEstado { get; set; }

        public string nombrePrioridad { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime fechaFin { get; set; }
        
        public string? comentario { get; set; }       
    }
}