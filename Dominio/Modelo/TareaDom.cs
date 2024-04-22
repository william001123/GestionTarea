
namespace Dominio.Modelo
{
    public class TareaDom
    {
        public int tareaID { get; set; }

        public string codTarea { get; set; }

        public DateTime fechaAdicion { get; set; }

        public string descripcion { get; set; }

        public string personaAsignada { get; set; }

        public string codEstado { get; set; }

        public string codPrioridad { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime fechaFin { get; set; }

        public string? comentario { get; set; }

        public PrioridadDom Prioridad { get; set; }

        public EstadoDom Estado { get; set; }

        public PersonaDom Persona { get; set; }

        public TareaDom()
        {
            tareaID = 0;
            codTarea = string.Empty;
            fechaAdicion = DateTime.Now;
            descripcion = string.Empty;
            personaAsignada = string.Empty;
            codEstado = string.Empty;
            codPrioridad = string.Empty;
            fechaInicio = DateTime.MinValue;
            fechaFin = DateTime.MaxValue;
            comentario = string.Empty;

            Prioridad = new PrioridadDom();
            Estado = new EstadoDom();
            Persona = new PersonaDom();
        }

    }
}