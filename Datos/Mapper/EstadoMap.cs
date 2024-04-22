using Datos.Entidad;
using Dominio.Modelo;

namespace Datos.Mapper
{
    public static class EstadoMap
    {
        public static EstadoEnt Map(this EstadoDom model)
        {
            return new EstadoEnt()
            {
                codEstado = model.codEstado,
                nombreEstado = model.nombreEstado
            };
        }

        public static List<EstadoEnt> Map(this List<EstadoDom> model)
        {
            List<EstadoEnt> dtos = new List<EstadoEnt>();

            foreach (EstadoDom modelItem in model)
            {
                dtos.Add(Map(modelItem));
            }

            return dtos;
        }

        public static List<EstadoDom> Map(this List<EstadoEnt> model)
        {
            List<EstadoDom> dtos = new List<EstadoDom>();

            foreach (EstadoEnt modelItem in model)
            {
                dtos.Add(Map(modelItem));                
            }

            return dtos;
        }

        public static EstadoDom Map(this EstadoEnt dto)
        {
            return new EstadoDom()
            {
                codEstado = dto.codEstado,
                nombreEstado = dto.nombreEstado
            };
        }
    }
}
