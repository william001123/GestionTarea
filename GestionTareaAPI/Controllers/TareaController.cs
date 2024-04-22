using Aplicacion.Interface;
using Dominio.Modelo;
using Microsoft.AspNetCore.Mvc;
using static Dominio.Maestras.MensajesBase;
using DTO.DTO;
using DTO.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace GestionTareaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReglasCors")]
    [Authorize]
    public class TareaController : ControllerBase
    {

        private readonly IServTarea<TareaDom, int> db;

        public TareaController(IServTarea<TareaDom, int> _db)
        {
            db = _db;
        }

        [HttpGet("{order}")]
        public ActionResult<List<TareaObtDTO>> ObtenerTodo(string order)
        {
            return Ok(db.ObtenerTodo(order).Map2());
        }

        [HttpGet]
        public ActionResult<List<TareaObtDTO>> ObtenerPorFiltro([FromQuery] string order = "ASC", [FromQuery]  string? personaAsignada = null,
            [FromQuery] string? codEstado = null, [FromQuery] string? codPrioridad = null, [FromQuery] DateTime? fechaInicio = null)
        {
            TareaObtParaDTO entidad = new TareaObtParaDTO();

            entidad.personaAsignada = personaAsignada ?? "";
            entidad.codEstado = codEstado ?? "";
            entidad.codPrioridad = codPrioridad ?? "";
            entidad.fechaInicio = fechaInicio ?? default;

            return Ok(db.ObtenerPorFiltro(entidad.Map(), order).Map2());
        }

        [HttpPost]
        public ActionResult Insertar([FromBody] TareaInsertDTO entidad)
        {
            db.Insertar(entidad.Map());
            return Ok(Satisfactorio.Insertado.GetEnumDescription());

        }

        [HttpPut]
        public ActionResult Actualizar([FromBody] TareaDTO entidad)
        {
            db.Actualizar(entidad.Map());
            return Ok(Satisfactorio.Actualizado.GetEnumDescription());
        }

        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            db.Eliminar(id);
            return Ok(Satisfactorio.Eliminado.GetEnumDescription());
        }
    }
}
