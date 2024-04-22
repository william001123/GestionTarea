using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datos.Entidad
{
    public class TareaEnt
    {
        [Key]
        [Required]
        public int tareaID { get; set; }

        [Required]
        [StringLength(15)]
        public string codTarea { get; set; }

        public DateTime fechaAdicion { get; set; }

        [Required]
        [StringLength(5000)]
        public string descripcion { get; set; }

        [ForeignKey("PersonaEnt"), Column(Order = 0)]
        [StringLength(20)]
        public string personaAsignada { get; set; }

        [ForeignKey("EstadoEnt"), Column(Order = 0)]
        [StringLength(15)]
        public string codEstado { get; set; }

        [ForeignKey("PrioridadEnt"), Column(Order = 0)]
        [StringLength(15)]
        public string codPrioridad { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime fechaFin { get; set; }

        [StringLength(200)]
        public string? comentario { get; set; }

        public PrioridadEnt Prioridad { get; set; }

        public EstadoEnt Estado { get; set; }

        public PersonaEnt Persona { get; set; }
    }
}