
using System.ComponentModel.DataAnnotations;

namespace DTO.DTO
{
    public class PersonaDTO
    {
        [Required]
        public string usuario { get; set; }

        [Required]
        public string nombre { get; set; }
    }
}
