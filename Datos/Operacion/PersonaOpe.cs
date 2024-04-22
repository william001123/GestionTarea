using Datos.Contexto;
using Datos.Mapper;
using Dominio.Interface.Repositorio;
using Dominio.Modelo;

namespace Datos.Operacion
{
    public class PersonaOpe : IRepoBase<PersonaDom, string>
    {
        private GestionTareaContexto db;

        public PersonaOpe(GestionTareaContexto _db)
        {
            db = _db;
        }

        public void Actualizar(PersonaDom entidad)
        {
            var selecc = db.PersonaEnt.Where(olinea => olinea.usuario == entidad.usuario).FirstOrDefault();

            if (selecc != null)
            {
                selecc.usuario = entidad.usuario;
                selecc.nombre = entidad.nombre;               

                db.Entry(selecc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(string entidadID)
        {
            var selecc = db.PersonaEnt.Where(olinea => olinea.usuario == entidadID).FirstOrDefault();

            if (selecc != null)
            {
                db.PersonaEnt.Remove(selecc);
            }
        }

        public PersonaDom Insertar(PersonaDom entidad)
        {
            db.PersonaEnt.Add(entidad.Map());
            return entidad;
        }

        public PersonaDom ObtenerPorID(string entidadID)
        {
            var selecc = db.PersonaEnt.Where(olinea => (olinea.usuario == entidadID)).FirstOrDefault();

            return selecc.Map();
        }

        public List<PersonaDom> ObtenerTodo()
        {
            return db.PersonaEnt.ToList().Map();
        }

        public void SalvarTodo()
        {
            db.SaveChanges();
        }
    }
}
