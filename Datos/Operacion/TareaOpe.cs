using Datos.Contexto;
using Datos.Mapper;
using Dominio.Interface.Repositorio;
using Dominio.Modelo;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Datos.Operacion
{
    public class TareaOpe : IRepoTarea<TareaDom, int>
    {
        private GestionTareaContexto db;
        private readonly string _order = "ASC";

        public TareaOpe(GestionTareaContexto _db)
        {
            db = _db;
        }

        public void Actualizar(TareaDom entidad)
        {
            var selecc = db.TareaEnt.Where(olinea => olinea.tareaID == entidad.tareaID).FirstOrDefault();

            if (selecc != null)
            {
                selecc.codEstado = entidad.codEstado;
                selecc.fechaFin = entidad.fechaFin;
                selecc.personaAsignada = entidad.personaAsignada;
                selecc.comentario = entidad.comentario;

                db.Entry(selecc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(int entidad)
        {
            var selecc = db.TareaEnt.Where(olinea => olinea.tareaID == entidad).FirstOrDefault();

            if (selecc != null)
            {
                db.TareaEnt.Remove(selecc);
            }
        }

        public TareaDom Insertar(TareaDom entidad)
        {
            db.TareaEnt.Add(entidad.Map());
            return entidad;
        }

        //public TareaDom ObtenerPorFiltro(TareaDom entidad, string order)
        //{
        //    var _order = "ASC";

        //    var query = db.TareaEnt.Where(olinea => (olinea.codEstado == entidad.codEstado || entidad.codEstado == "")
        //             && (olinea.fechaInicio == entidad.fechaInicio || entidad.fechaInicio == DateTime.MinValue)
        //             && (olinea.personaAsignada == entidad.personaAsignada || entidad.personaAsignada == "")
        //             && (olinea.codPrioridad == entidad.codPrioridad || entidad.codPrioridad == ""));

        //    var selecc = (order == _order) ? query.OrderBy(olinea => olinea.fechaAdicion).FirstOrDefault() : query.OrderByDescending(olinea => olinea.fechaAdicion).FirstOrDefault();            

        //    return selecc.Map();
        //}


        public List<TareaDom> ObtenerPorFiltro(TareaDom entidad, string order)
        {            

            var query = db.TareaEnt.Include(t => t.Persona) // Incluir la información de PersonaEnt
                                    .Include(t => t.Estado)  // Incluir la información de EstadoEnt
                                    .Include(t => t.Prioridad)  // Incluir la información de PrioridadEnt
                                    .Where(olinea => (olinea.codEstado == entidad.codEstado || entidad.codEstado == "")
                                            && (olinea.fechaInicio == entidad.fechaInicio || entidad.fechaInicio == DateTime.MinValue)
                                            && (olinea.personaAsignada == entidad.personaAsignada || entidad.personaAsignada == "")
                                            && (olinea.codPrioridad == entidad.codPrioridad || entidad.codPrioridad == "")
                                        );

            var selecc = (order == _order) ? query.OrderBy(olinea => olinea.fechaAdicion).ToList() : query.OrderByDescending(olinea => olinea.fechaAdicion).ToList();

            return (selecc == null) ? new List<TareaDom>() : selecc.Map();
        }

        public TareaDom ObtenerPorID(int entidadID, string codTarea, DateTime fechaInicio)
        {

            var selecc = db.TareaEnt.Where(olinea => (olinea.tareaID == entidadID || entidadID == 0)
                      && (olinea.codTarea == codTarea || codTarea == "")
                      && (olinea.fechaInicio == fechaInicio || fechaInicio == DateTime.MinValue)).FirstOrDefault();

            return (selecc == null) ? new TareaDom() : selecc.Map2();
        }

        public List<TareaDom> ObtenerTodo(string order)
        {
            var query = db.TareaEnt.Include(t => t.Persona) // Incluir la información de PersonaEnt
                                    .Include(t => t.Estado)  // Incluir la información de EstadoEnt
                                    .Include(t => t.Prioridad);  // Incluir la información de PrioridadEnt;
            var selecc = (order == _order) ? query.OrderBy(olinea => olinea.fechaAdicion).ToList() : query.OrderByDescending(olinea => olinea.fechaAdicion).ToList();
            return selecc.Map();
        }

        public void SalvarTodo()
        {
            db.SaveChanges();
        }
    }
}
