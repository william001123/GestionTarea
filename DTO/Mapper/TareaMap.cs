using Dominio.Modelo;
using DTO.DTO;

namespace DTO.Mapper
{
    public static class TareaMap
    {

        public static TareaDom Map(this TareaDTO dto)
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
            };
        }        

        public static TareaDom Map(this TareaInsertDTO dto)
        {
            return new TareaDom()
            {
                codTarea = dto.codTarea,
                descripcion = dto.descripcion,
                personaAsignada = dto.personaAsignada,
                codEstado = dto.codEstado,
                codPrioridad = dto.codPrioridad,
                fechaInicio = dto.fechaInicio,
                fechaFin = dto.fechaFin,
                comentario = dto.comentario ?? new TareaDom().comentario
            };
        }

        public static TareaDom Map(this TareaObtParaDTO dto)
        {
            return new TareaDom()
            {
                personaAsignada = dto.personaAsignada,
                codEstado = dto.codEstado,
                codPrioridad = dto.codPrioridad,
                fechaInicio = dto.fechaInicio,
            };
        }

        public static TareaObtDTO Map2(this TareaDom model)
        {
            return new TareaObtDTO()
            {
                codTarea = model.codTarea,
                fechaAdicion = model.fechaAdicion,
                descripcion = model.descripcion,
                nombrePersonaAsignada = model.Persona.nombre,
                nombreEstado = model.Estado.nombreEstado,
                nombrePrioridad = model.Prioridad.nombrePrioridad,
                fechaInicio = model.fechaInicio,
                fechaFin = model.fechaFin,
                comentario = model.comentario,
            };
        }

        public static List<TareaObtDTO> Map2(this List<TareaDom> model)
        {
            List<TareaObtDTO> dtos = new List<TareaObtDTO>();

            foreach (TareaDom modelItem in model)
            {
                dtos.Add(Map2(modelItem));
            }

            return dtos;
        }
    }
}
