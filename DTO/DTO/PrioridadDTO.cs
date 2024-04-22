
using System.ComponentModel.DataAnnotations;

namespace DTO.DTO
{
    public class PrioridadDTO
    {
        [Required]
        public string codPrioridad { get; set; }

        [Required]
        public string nombrePrioridad { get; set; }
    }
}
