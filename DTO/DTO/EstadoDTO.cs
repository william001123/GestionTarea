
using System.ComponentModel.DataAnnotations;

namespace DTO.DTO
{
    public class EstadoDTO
    {
        [Required]
        public string codEstado { get; set; }

        [Required]
        public string nombreEstado { get; set; }
        
    }
}
