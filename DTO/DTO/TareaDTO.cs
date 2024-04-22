
using System.ComponentModel.DataAnnotations;

namespace DTO.DTO
{
    public class TareaDTO
    {        
        public int tareaID { get; set; }

        [Required]
        public string codTarea { get; set; }

        [Required]
        public DateTime fechaAdicion { get; set; }

        [Required]
        public string descripcion { get; set; }

        [Required]
        public string personaAsignada { get; set; }

        [Required]
        public string codEstado { get; set; }

        [Required]
        public string codPrioridad { get; set; }

        [Required]
        public DateTime fechaInicio { get; set; }

        [Required]
        public DateTime fechaFin { get; set; }
        
        public string? comentario { get; set; }       
    }
}