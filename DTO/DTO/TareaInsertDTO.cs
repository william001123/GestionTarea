
using System.ComponentModel.DataAnnotations;

namespace DTO.DTO
{
    public class TareaInsertDTO
    {

        [Required]
        public string codTarea { get; set; }

        [Required]
        public DateTime fechaInicio { get; set; }

        [Required]
        public DateTime fechaFin { get; set; }
        [Required]
        public string personaAsignada { get; set; }

        [Required]
        public string descripcion { get; set; }        

        [Required]
        public string codEstado { get; set; }

        [Required]
        public string codPrioridad { get; set; }       
        
        public string? comentario { get; set; }       
    }
}