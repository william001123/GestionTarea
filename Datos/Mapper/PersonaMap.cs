using Datos.Entidad;
using Dominio.Modelo;

namespace Datos.Mapper
{
    public static class PersonaMap
    {
        public static PersonaEnt Map(this PersonaDom model)
        {
            return new PersonaEnt()
            {
                usuario = model.usuario,
                nombre = model.nombre
            };
        }

        public static List<PersonaEnt> Map(this List<PersonaDom> model)
        {
            List<PersonaEnt> dtos = new List<PersonaEnt>();

            foreach (PersonaDom modelItem in model)
            {
                dtos.Add(Map(modelItem));
            }

            return dtos;
        }

        public static List<PersonaDom> Map(this List<PersonaEnt> model)
        {
            List<PersonaDom> dtos = new List<PersonaDom>();

            foreach (PersonaEnt modelItem in model)
            {
                dtos.Add(Map(modelItem));                
            }

            return dtos;
        }

        public static PersonaDom Map(this PersonaEnt dto)
        {
            return new PersonaDom()
            {
                usuario = dto.usuario,
                nombre = dto.nombre
            };
        }
    }
}
