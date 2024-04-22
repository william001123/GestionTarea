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
    public class PersonaController : ControllerBase
    {

        private readonly IServBase<PersonaDom, string> db;

        public PersonaController(IServBase<PersonaDom, string> _db)
        {
            db = _db;
        }

        [HttpGet]
        public ActionResult<List<PersonaDTO>> ObtenerTodo()
        {
            return Ok(db.ObtenerTodo().Map());
        }

        [HttpGet("{id}")]
        public ActionResult<List<PersonaDTO>> ObtenetPorID(string id)
        {
            return Ok(db.ObtenerPorID(id).Map());
        }

        [HttpPost]
        public ActionResult Insertar([FromBody] PersonaDTO entidad)
        {
            db.Insertar(entidad.Map());
            return Ok(Satisfactorio.Insertado.GetEnumDescription());

        }

        //[HttpPut("{id}")]
        [HttpPut]
        public ActionResult Actualizar([FromBody] PersonaDTO entidad)
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
