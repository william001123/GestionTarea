using Aplicacion.Interface;
using Dominio.Modelo;
using Microsoft.AspNetCore.Mvc;
using static Dominio.Maestras.MensajesBase;
using DTO.DTO;
using DTO.Mapper;

namespace GestionTareaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Cuando el end point retorna el token y se quiera probar en Swagger se debe poner Bearer antes del token en la Autorizacion, ejm
    //Bearer eyJhbGciOiJIUzI1NiIsI
    //Si se va a probar en postman, el token se pone en el tipo de autorizacion Bearer Token, y ahí se pone el token

    public class AutenticacionController : ControllerBase
    {

        private readonly IServAutenticacion<AutenticacionDom, string> db;

        public AutenticacionController(IServAutenticacion<AutenticacionDom, string> _db)
        {
            db = _db;
        }

        [HttpPost]
        public ActionResult Insertar([FromBody] AutenticacionDTO entidad)
        {
            db.Insertar(entidad.Map());
            return Ok(Satisfactorio.Insertado.GetEnumDescription());

        }

        [HttpPost]
        [Route("Validar")]
        public ActionResult ObtenerAutenticacion([FromBody] AutenticacionDTO autenticacion)
        {
            var selec = db.ObtenerAutenticacion(autenticacion.usuario, autenticacion.contrasena).Map();

            if (selec != null)
            {
                var tokencreado = db.Token(autenticacion.usuario);
                return StatusCode(StatusCodes.Status200OK, new { token = tokencreado });
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }
    }
}
