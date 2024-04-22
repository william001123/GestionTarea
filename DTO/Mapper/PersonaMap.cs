using Dominio.Modelo;
using DTO.DTO;

namespace DTO.Mapper
{
    public static class PersonaMap
    {
        public static PersonaDTO Map(this PersonaDom model)
        {
            return new PersonaDTO()
            {
                usuario = model.usuario,
                nombre = model.nombre
            };
        }

        public static List<PersonaDTO> Map(this List<PersonaDom> model)
        {
            List<PersonaDTO> dtos = new List<PersonaDTO>();

            foreach (PersonaDom modelItem in model)
            {
                dtos.Add(Map(modelItem));
            }

            return dtos;
        }

        public static List<PersonaDom> Map(this List<PersonaDTO> model)
        {
            List<PersonaDom> dtos = new List<PersonaDom>();

            foreach (PersonaDTO modelItem in model)
            {
                dtos.Add(Map(modelItem));                
            }

            return dtos;
        }

        public static PersonaDom Map(this PersonaDTO dto)
        {
            return new PersonaDom()
            {
                usuario = dto.usuario,
                nombre = dto.nombre
            };
        }
    }
}
