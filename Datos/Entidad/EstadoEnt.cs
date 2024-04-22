using System.ComponentModel.DataAnnotations;

namespace Datos.Entidad
{
    public class EstadoEnt
    {
        [Required]
        [StringLength(15)]
        [Key]
        public string codEstado { get; set; }

        [Required]
        [StringLength(25)]
        public string nombreEstado { get; set; }

        public IList<TareaEnt> Tareas { get; set; }
    }
}
