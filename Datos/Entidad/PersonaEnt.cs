using System.ComponentModel.DataAnnotations;

namespace Datos.Entidad
{
    public class PersonaEnt
    {
        [Required]
        [StringLength(20)]
        [Key]
        public string usuario { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        public AutenticacionEnt Autenticacion { get; set; }

        public IList<TareaEnt> Tareas { get; set; }
    }
}
