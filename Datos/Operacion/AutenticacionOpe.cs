using Datos.Contexto;
using Datos.Mapper;
using Dominio.Interface.Repositorio;
using Dominio.Modelo;

namespace Datos.Operacion
{
    public class AutenticacionOpe : IRepoAutenticacion<AutenticacionDom, string>
    {
        private GestionTareaContexto db;

        public AutenticacionOpe(GestionTareaContexto _db)
        {
            db = _db;
        }

        public AutenticacionDom Insertar(AutenticacionDom entidad)
        {
            db.AutenticacionEnt.Add(entidad.Map());
            return entidad;
        }

        public AutenticacionDom ObtenerAutenticacion(string usuario, string contrasena)
        {

            var Selecc = db.AutenticacionEnt.Where(olinea => olinea.usuario == usuario && olinea.contrasena == contrasena).FirstOrDefault();

            if (Selecc == null)
                return new AutenticacionDom();
            else
                return Selecc.Map();
        }

        public void SalvarTodo()
        {
            db.SaveChanges();
        }
    }
}
