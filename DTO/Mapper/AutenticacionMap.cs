using Dominio.Modelo;
using DTO.DTO;

namespace DTO.Mapper
{
    public static class AutenticacionMap
    {
        public static AutenticacionDTO Map(this AutenticacionDom model)
        {
            return new AutenticacionDTO()
            {
                usuario = model.usuario,
                contrasena = model.contrasena
            };
        }

        public static List<AutenticacionDTO> Map(this List<AutenticacionDom> model)
        {
            List<AutenticacionDTO> dtos = new List<AutenticacionDTO>();

            foreach (AutenticacionDom modelItem in model)
            {
                dtos.Add(Map(modelItem));
            }

            return dtos;
        }

        public static List<AutenticacionDom> Map(this List<AutenticacionDTO> model)
        {
            List<AutenticacionDom> dtos = new List<AutenticacionDom>();

            foreach (AutenticacionDTO modelItem in model)
            {
                dtos.Add(Map(modelItem));                
            }

            return dtos;
        }

        public static AutenticacionDom Map(this AutenticacionDTO dto)
        {
            return new AutenticacionDom()
            {
                usuario = dto.usuario,
                contrasena = dto.contrasena
            };
        }
    }
}
