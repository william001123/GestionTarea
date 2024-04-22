using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datos.Entidad
{
    public class AutenticacionEnt
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        [ForeignKey("PersonaEnt"), Column(Order = 0)]
        public string usuario { get; set; }

        [Required]
        [StringLength(20)]
        public string contrasena { get; set; }

        public PersonaEnt Persona { get; set; }

    }
}
