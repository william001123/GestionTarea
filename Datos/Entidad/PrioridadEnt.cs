using System.ComponentModel.DataAnnotations;

namespace Datos.Entidad
{
    public class PrioridadEnt
    {
        [Required]
        [StringLength(15)]
        [Key]
        public string codPrioridad { get; set; }

        [Required]
        [StringLength(25)]
        public string nombrePrioridad { get; set; }

        public IList<TareaEnt> Tareas { get; set; }
    }
}
