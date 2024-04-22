using Datos.Entidad;
using Dominio.Modelo;

namespace Datos.Mapper
{
    public static class TareaMap
    {
        public static TareaEnt Map(this TareaDom model)
        {
            return new TareaEnt()
            {
                tareaID = model.tareaID,
                codTarea = model.codTarea,
                fechaAdicion = model.fechaAdicion,
                descripcion = model.descripcion,
                personaAsignada = model.personaAsignada,
                codEstado = model.codEstado,
                codPrioridad = model.codPrioridad,
                fechaInicio = model.fechaInicio,
                fechaFin = model.fechaFin,
                comentario = model.comentario,
            };
        }

        public static List<TareaEnt> Map(this List<TareaDom> model)
        {
            List<TareaEnt> dtos = new List<TareaEnt>();

            foreach (TareaDom modelItem in model)
            {
                dtos.Add(Map(modelItem));                
            }

            return dtos;
        }

        public static List<TareaDom> Map(this List<TareaEnt> model)
        {
            List<TareaDom> dtos = new List<TareaDom>();

            foreach (TareaEnt modelItem in model)
            {
                dtos.Add(Map(modelItem));                
            }

            return dtos;
        }

        public static TareaDom Map(this TareaEnt dto)
        {
            return new TareaDom()
            {
                tareaID = dto.tareaID,
                codTarea = dto.codTarea,
                fechaAdicion = dto.fechaAdicion,
                descripcion = dto.descripcion,
                personaAsignada = dto.personaAsignada,
                codEstado = dto.codEstado,
                codPrioridad = dto.codPrioridad,
                fechaInicio = dto.fechaInicio,
                fechaFin = dto.fechaFin,
                comentario = dto.comentario,

                Persona = dto.Persona.Map(),
                Prioridad = dto.Prioridad.Map(),
                Estado = dto.Estado.Map(),
            };
        }

        public static TareaDom Map2(this TareaEnt dto)
        {
            return new TareaDom()
            {
                tareaID = dto.tareaID,
                codTarea = dto.codTarea,
                fechaAdicion = dto.fechaAdicion,
                descripcion = dto.descripcion,
                personaAsignada = dto.personaAsignada,
                codEstado = dto.codEstado,
                codPrioridad = dto.codPrioridad,
                fechaInicio = dto.fechaInicio,
                fechaFin = dto.fechaFin,
                comentario = dto.comentario
            };
        }
    }
}
