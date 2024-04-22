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
    public class EstadoController : ControllerBase
    {

        private readonly IServBase<EstadoDom, string> db;

        public EstadoController(IServBase<EstadoDom, string> _db)
        {
            db = _db;
        }

        [HttpGet]
        public ActionResult<List<EstadoDTO>> ObtenerTodo()
        {
            return Ok(db.ObtenerTodo().Map());
        }

        [HttpGet("{id}")]
        public ActionResult<List<EstadoDTO>> ObtenetPorID(string id)
        {
            return Ok(db.ObtenerPorID(id).Map());
        }

        [HttpPost]
        public ActionResult Insertar([FromBody] EstadoDTO entidad)
        {
            db.Insertar(entidad.Map());
            return Ok(Satisfactorio.Insertado.GetEnumDescription());

        }

        //[HttpPut("{id}")]
        [HttpPut]
        public ActionResult Actualizar([FromBody] EstadoDTO entidad)
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
