
using System.ComponentModel.DataAnnotations;

namespace DTO.DTO
{
    public class TareaObtParaDTO
    {        
        public string personaAsignada { get; set; }

        public string codEstado { get; set; }

        public string codPrioridad { get; set; }

        public DateTime fechaInicio { get; set; }         
    }
}