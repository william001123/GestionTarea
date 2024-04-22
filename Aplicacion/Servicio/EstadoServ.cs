
using Aplicacion.Interface;
using Dominio.Maestras;
using Dominio.Interface.Repositorio;
using Dominio.Modelo;
using static Dominio.Maestras.MensajesBase;

namespace Aplicacion.Servicio
{
    public class EstadoServ
        : IServBase<EstadoDom, string>
    {
        private readonly IRepoBase<EstadoDom, string> repo;
        private Excepcion excepcion = new Excepcion();

        public EstadoServ(IRepoBase<EstadoDom, string> _repo)
        {
            repo = _repo;            
        }

        public void Actualizar(EstadoDom entidad)
        {
            try
            {
                repo.Actualizar(entidad);
                repo.SalvarTodo();
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Actualizar.GetEnumDescription());
            }
        }

        public void Eliminar(string entidadID)
        {
            try
            {
                repo.Eliminar(entidadID);
                repo.SalvarTodo();
            }
            catch (Exception ex)
            {

                throw excepcion.Error(ex, Error.Eliminar.GetEnumDescription());
            }
        }

        public EstadoDom Insertar(EstadoDom entidad)
        {
            try
            {
                var result = repo.Insertar(entidad);
                repo.SalvarTodo();
                return result;
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Insertar.GetEnumDescription());
            }
        }

        public EstadoDom ObtenerPorID(string entidadID)
        {
            try
            {
                return repo.ObtenerPorID(entidadID);
            }
            catch (Exception ex)
            {

                throw excepcion.Error(ex, Error.Obtener.GetEnumDescription());
            }
        }

        public List<EstadoDom> ObtenerTodo()
        {
            try
            {
                return repo.ObtenerTodo();
            }
            catch (Exception ex)
            {

                throw excepcion.Error(ex, Error.Obtener.GetEnumDescription());
            }
        }
    }
}
