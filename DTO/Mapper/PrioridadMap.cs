using Dominio.Modelo;
using DTO.DTO;

namespace DTO.Mapper
{
    public static class PrioridadMap
    {
        public static PrioridadDTO Map(this PrioridadDom model)
        {
            return new PrioridadDTO()
            {
                codPrioridad = model.codPrioridad,
                nombrePrioridad = model.nombrePrioridad
            };
        }

        public static List<PrioridadDTO> Map(this List<PrioridadDom> model)
        {
            List<PrioridadDTO> dtos = new List<PrioridadDTO>();

            foreach (PrioridadDom modelItem in model)
            {
                dtos.Add(Map(modelItem));
            }

            return dtos;
        }

        public static List<PrioridadDom> Map(this List<PrioridadDTO> model)
        {
            List<PrioridadDom> dtos = new List<PrioridadDom>();

            foreach (PrioridadDTO modelItem in model)
            {
                dtos.Add(Map(modelItem));                
            }

            return dtos;
        }

        public static PrioridadDom Map(this PrioridadDTO dto)
        {
            return new PrioridadDom()
            {
                codPrioridad = dto.codPrioridad,
                nombrePrioridad = dto.nombrePrioridad
            };
        }
    }
}
