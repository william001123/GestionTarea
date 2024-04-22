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
    public class PrioridadController : ControllerBase
    {

        private readonly IServBase<PrioridadDom, string> db;

        public PrioridadController(IServBase<PrioridadDom, string> _db)
        {
            db = _db;
        }

        [HttpGet]
        public ActionResult<List<PrioridadDTO>> ObtenerTodo()
        {
            return Ok(db.ObtenerTodo().Map());
        }

        [HttpGet("{id}")]
        public ActionResult<List<PrioridadDTO>> ObtenetPorID(string id)
        {
            return Ok(db.ObtenerPorID(id).Map());
        }

        [HttpPost]
        public ActionResult Insertar([FromBody] PrioridadDTO entidad)
        {
            db.Insertar(entidad.Map());
            return Ok(Satisfactorio.Insertado.GetEnumDescription());

        }

        //[HttpPut("{id}")]
        [HttpPut]
        public ActionResult Actualizar([FromBody] PrioridadDTO entidad)
        {
            db.Actualizar(entidad.Map());
            return Ok(Satisfactorio.Actualizado.GetEnumDescription());
        }

        [HttpDelete("{id}")]
        public ActionResult Eliminar(string id)
        {
            db.Eliminar(id);
            return Ok(Satisfactorio.Eliminado.GetEnumDescription());
        }
    }
}
