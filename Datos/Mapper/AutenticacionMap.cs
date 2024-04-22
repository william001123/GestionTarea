using Datos.Entidad;
using Dominio.Modelo;

namespace Datos.Mapper
{
    public static class AutenticacionMap
    {
        public static AutenticacionEnt Map(this AutenticacionDom model)
        {
            return new AutenticacionEnt()
            {
                usuario = model.usuario,
                contrasena = model.contrasena
            };
        }

        public static List<AutenticacionEnt> Map(this List<AutenticacionDom> model)
        {
            List<AutenticacionEnt> dtos = new List<AutenticacionEnt>();

            foreach (AutenticacionDom modelItem in model)
            {
                dtos.Add(Map(modelItem));
            }

            return dtos;
        }

        public static List<AutenticacionDom> Map(this List<AutenticacionEnt> model)
        {
            List<AutenticacionDom> dtos = new List<AutenticacionDom>();

            foreach (AutenticacionEnt modelItem in model)
            {
                dtos.Add(Map(modelItem));                
            }

            return dtos;
        }

        public static AutenticacionDom Map(this AutenticacionEnt dto)
        {
            return new AutenticacionDom()
            {
                usuario = dto.usuario,
                contrasena = dto.contrasena
            };
        }
    }
}
