
using Aplicacion.Interface;
using Dominio.Maestras;
using Dominio.Interface.Repositorio;
using Dominio.Modelo;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Dominio.Maestras.MensajesBase;

namespace Aplicacion.Servicio
{
    public class AutenticacionServ
        : IServAutenticacion<AutenticacionDom, string>
    {
        private readonly IRepoAutenticacion<AutenticacionDom, string> repo;
        private Excepcion excepcion = new Excepcion();
        private string secretKey = "";

        public AutenticacionServ(IRepoAutenticacion<AutenticacionDom, string> _repo, IConfiguration config)
        {
            repo = _repo;
            secretKey = config.GetSection("settings").GetSection("secretKey").ToString();
        }

        public AutenticacionDom Insertar(AutenticacionDom entidad)
        {
            try
            {
                entidad.contrasena = Encrypt.Encriptar(entidad.contrasena);
                var result = repo.Insertar(entidad);
                repo.SalvarTodo();
                return result;
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Insertar.GetEnumDescription());
            }
        }

        public AutenticacionDom ObtenerAutenticacion(string Usuario, string Contrasena)
        {
            Contrasena = Encrypt.Encriptar(Contrasena);
            return repo.ObtenerAutenticacion(Usuario, Contrasena);
        }

        public string Token(string Usuario)
        {
            var keyBytes = Encoding.ASCII.GetBytes(secretKey);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, Usuario));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokencreado = tokenHandler.WriteToken(tokenConfig);

            return tokencreado;
        }

    }
}
