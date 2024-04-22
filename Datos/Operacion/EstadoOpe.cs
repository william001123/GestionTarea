using Datos.Contexto;
using Datos.Mapper;
using Dominio.Interface.Repositorio;
using Dominio.Modelo;

namespace Datos.Operacion
{
    public class EstadoOpe : IRepoBase<EstadoDom, string>
    {
        private GestionTareaContexto db;

        public EstadoOpe(GestionTareaContexto _db)
        {
            db = _db;
        }

        public void Actualizar(EstadoDom entidad)
        {
            var selecc = db.EstadoEnt.Where(olinea => olinea.codEstado == entidad.codEstado).FirstOrDefault();

            if (selecc != null)
            {
                selecc.codEstado = entidad.codEstado;
                selecc.nombreEstado = entidad.nombreEstado;               

                db.Entry(selecc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(string entidadID)
        {
            var selecc = db.EstadoEnt.Where(olinea => olinea.codEstado == entidadID).FirstOrDefault();

            if (selecc != null)
            {
                db.EstadoEnt.Remove(selecc);
            }
        }

        public EstadoDom Insertar(EstadoDom entidad)
        {
            db.EstadoEnt.Add(entidad.Map());
            return entidad;
        }

        public EstadoDom ObtenerPorID(string entidadID)
        {
            var selecc = db.EstadoEnt.Where(olinea => (olinea.codEstado == entidadID)).FirstOrDefault();

            return selecc.Map();
        }

        public List<EstadoDom> ObtenerTodo()
        {
            return db.EstadoEnt.ToList().Map();
        }

        public void SalvarTodo()
        {
            db.SaveChanges();
        }
    }
}
