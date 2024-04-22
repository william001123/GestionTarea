using Dominio.Modelo;
using DTO.DTO;

namespace DTO.Mapper
{
    public static class EstadoMap
    {
        public static EstadoDTO Map(this EstadoDom model)
        {
            return new EstadoDTO()
            {
                codEstado = model.codEstado,
                nombreEstado = model.nombreEstado
            };
        }

        public static List<EstadoDTO> Map(this List<EstadoDom> model)
        {
            List<EstadoDTO> dtos = new List<EstadoDTO>();

            foreach (EstadoDom modelItem in model)
            {
                dtos.Add(Map(modelItem));
            }

            return dtos;
        }

        public static List<EstadoDom> Map(this List<EstadoDTO> model)
        {
            List<EstadoDom> dtos = new List<EstadoDom>();

            foreach (EstadoDTO modelItem in model)
            {
                dtos.Add(Map(modelItem));                
            }

            return dtos;
        }

        public static EstadoDom Map(this EstadoDTO dto)
        {
            return new EstadoDom()
            {
                codEstado = dto.codEstado,
                nombreEstado = dto.nombreEstado
            };
        }
    }
}
