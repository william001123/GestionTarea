using Datos.Entidad;
using Dominio.Modelo;

namespace Datos.Mapper
{
    public static class PrioridadMap
    {
        public static PrioridadEnt Map(this PrioridadDom model)
        {
            return new PrioridadEnt()
            {
                codPrioridad = model.codPrioridad,
                nombrePrioridad = model.nombrePrioridad
            };
        }

        public static List<PrioridadEnt> Map(this List<PrioridadDom> model)
        {
            List<PrioridadEnt> dtos = new List<PrioridadEnt>();

            foreach (PrioridadDom modelItem in model)
            {
                dtos.Add(Map(modelItem));
            }

            return dtos;
        }

        public static List<PrioridadDom> Map(this List<PrioridadEnt> model)
        {
            List<PrioridadDom> dtos = new List<PrioridadDom>();

            foreach (PrioridadEnt modelItem in model)
            {
                dtos.Add(Map(modelItem));                
            }

            return dtos;
        }

        public static PrioridadDom Map(this PrioridadEnt dto)
        {
            return new PrioridadDom()
            {
                codPrioridad = dto.codPrioridad,
                nombrePrioridad = dto.nombrePrioridad
            };
        }
    }
}
