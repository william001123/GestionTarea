using Datos.Contexto;
using Datos.Mapper;
using Dominio.Interface.Repositorio;
using Dominio.Modelo;

namespace Datos.Operacion
{
    public class PrioridadOpe : IRepoBase<PrioridadDom, string>
    {
        private GestionTareaContexto db;

        public PrioridadOpe(GestionTareaContexto _db)
        {
            db = _db;
        }
        
        public void Actualizar(PrioridadDom entidad)
        {
            var selecc = db.PrioridadEnt.Where(olinea => olinea.codPrioridad == entidad.codPrioridad).FirstOrDefault();

            if (selecc != null)
            {
                selecc.codPrioridad = entidad.codPrioridad;
                selecc.nombrePrioridad = entidad.nombrePrioridad;               

                db.Entry(selecc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(string entidadID)
        {
            var selecc = db.PrioridadEnt.Where(olinea => olinea.codPrioridad == entidadID).FirstOrDefault();

            if (selecc != null)
            {
                db.PrioridadEnt.Remove(selecc);
            }
        }

        public PrioridadDom Insertar(PrioridadDom entidad)
        {
            db.PrioridadEnt.Add(entidad.Map());
            return entidad;
        }

        public PrioridadDom ObtenerPorID(string entidadID)
        {
            var selecc = db.PrioridadEnt.Where(olinea => (olinea.codPrioridad == entidadID)).FirstOrDefault();

            return selecc.Map();
        }

        public List<PrioridadDom> ObtenerTodo()
        {
            return db.PrioridadEnt.ToList().Map();
        }

        public void SalvarTodo()
        {
            db.SaveChanges();
        }
    }
}
