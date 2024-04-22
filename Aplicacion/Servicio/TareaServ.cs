
using Aplicacion.Interface;
using Dominio.Maestras;
using Dominio.Interface.Repositorio;
using Dominio.Modelo;
using System.ComponentModel.DataAnnotations;
using static Dominio.Maestras.Maestra;
using static Dominio.Maestras.MensajesBase;
using System.Linq;

namespace Aplicacion.Servicio
{
    public class TareaServ
        : IServTarea<TareaDom, int>
    {
        private readonly IRepoTarea<TareaDom, int> repo;
        private Excepcion excepcion = new Excepcion();

        public TareaServ(IRepoTarea<TareaDom, int> _repo)
        {
            repo = _repo;
        }

        public void Actualizar(TareaDom entidad)
        {
            try
            {
                TareaDom oTarea = new TareaDom();

                oTarea = ObtenerPorID(entidad.tareaID, "", DateTime.Now);

                //Valida si el estado es finalizada
                if (oTarea.codPrioridad == Prioridad.alta.ToString() && oTarea.codEstado == Estado.enProceso.ToString())
                {
                    throw new ValidationException(ErrorOtro.ValidaEstadoProceso.GetEnumDescription());
                }

                //Valida si es prioridad alta y esta en estado en proceso
                if (oTarea.codPrioridad == Prioridad.alta.ToString() && oTarea.codEstado == Estado.enProceso.ToString())
                {
                    throw new ValidationException(ErrorOtro.ValidaEstadoProceso.GetEnumDescription());
                }

                //Valida si la fecha fin es menor a la fecha inicio
                if (oTarea.fechaFin < oTarea.fechaInicio)
                {
                    throw new ValidationException(ErrorOtro.ValidaFechaIniFin.GetEnumDescription());
                }

                //Solo se permite actualizar la persona asignada si el estado es nueva
                if (entidad.codEstado != Estado.nueva.ToString() && oTarea.personaAsignada != entidad.personaAsignada)
                {
                    throw new ValidationException(ErrorOtro.ValidaEstadoPersona.GetEnumDescription());
                }

                //Valida si la fecha fin es menor a la fecha actual, solo se puede actualizar el estado a cancelada
                if (oTarea.fechaFin < DateTime.Now && entidad.codEstado != Estado.cancelada.ToString())
                {
                    throw new ValidationException(ErrorOtro.ValidaFechaFinCancel.GetEnumDescription());
                }
                else if(oTarea.fechaFin < DateTime.Now && entidad.codEstado == Estado.cancelada.ToString())
                {
                    entidad = oTarea;
                    entidad.codEstado = Estado.cancelada.ToString();
                }

                repo.Actualizar(entidad);
                repo.SalvarTodo();
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Actualizar.GetEnumDescription());
            }
        }

        public void Eliminar(int entidadID)
        {
            try
            {
                TareaDom oTarea = new TareaDom();

                oTarea = ObtenerPorID(entidadID, "", DateTime.Now);

                //Valida si los estados son finalizada o en proceso
                if (new[] { Estado.finalizada.ToString(), Estado.enProceso.ToString() }.Contains(oTarea.codEstado))
                {
                    throw new ValidationException(ErrorOtro.ValidaEstadoEli.GetEnumDescription());
                }

                //Valida si ya cumplió el tiempo límite de ejecución
                if (oTarea.fechaFin < DateTime.Now)
                {
                    throw new ValidationException(ErrorOtro.ValidaFechaLimite.GetEnumDescription());
                }

                if (oTarea.codPrioridad == Prioridad.alta.ToString() && oTarea.codEstado == Estado.nueva.ToString())
                {
                    throw new ValidationException(ErrorOtro.ValidaEstadoPrio.GetEnumDescription());
                }

                repo.Eliminar(entidadID);
                repo.SalvarTodo();
            }
            catch (Exception ex)
            {

                throw excepcion.Error(ex, Error.Eliminar.GetEnumDescription());
            }
        }

        public TareaDom Insertar(TareaDom entidad)
        {
            try
            {
                TareaDom oTarea = new TareaDom();

                // Verificar que fechaInicio sea mayor o igual a la fecha actual
                if (entidad.fechaInicio < DateTime.Now)
                {
                    throw new ValidationException(ErrorOtro.ValidaFecha.GetEnumDescription());
                }

                //Valida si la prioridad es alta y tiene el comentario vacio
                if (entidad.codPrioridad == Prioridad.alta.ToString())
                {
                    if (entidad.comentario == "")
                    {
                        throw new ValidationException(ErrorOtro.ValidaComentario.GetEnumDescription());
                    }

                    if ((entidad.fechaFin - entidad.fechaInicio).TotalDays > 2)
                    {
                        throw new ValidationException(ErrorOtro.ValidaFecha2.GetEnumDescription());
                    }

                }

                //Valida si la fecha fin excede los 15 dias de la fecha inicio
                if ((entidad.fechaFin - entidad.fechaInicio).TotalDays > 15)
                {
                    throw new ValidationException(ErrorOtro.ValidaFecha15.GetEnumDescription());
                }

                //Valida si existe una tarea con el mismo codigo y la fecha inicio
                oTarea = ObtenerPorID(0, entidad.codTarea, entidad.fechaInicio);

                if (oTarea.tareaID != 0)
                {
                    throw new ValidationException(ErrorOtro.ValidaTarea.GetEnumDescription());
                }

                //Valida si la fecha fin es menor a la fecha inicio
                if (oTarea.fechaFin < oTarea.fechaInicio)
                {
                    throw new ValidationException(ErrorOtro.ValidaFechaIniFin.GetEnumDescription());
                }

                var result = repo.Insertar(entidad);
                repo.SalvarTodo();
                return result;
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Insertar.GetEnumDescription());
            }
        }

        public List<TareaDom> ObtenerPorFiltro(TareaDom entidad, string order)
        {
            try
            {
                return repo.ObtenerPorFiltro(entidad, order);
            }
            catch (Exception ex)
            {

                throw excepcion.Error(ex, Error.Obtener.GetEnumDescription());
            }
        }

        public TareaDom ObtenerPorID(int entidadID, string codTarea, DateTime fechaInicio)
        {
            try
            {
                return repo.ObtenerPorID(entidadID, codTarea, fechaInicio);
            }
            catch (Exception ex)
            {
                throw excepcion.Error(ex, Error.Obtener.GetEnumDescription());
            }
        }

        public List<TareaDom> ObtenerTodo(string order)
        {
            try
            {
                return repo.ObtenerTodo(order);
            }
            catch (Exception ex)
            {

                throw excepcion.Error(ex, Error.Obtener.GetEnumDescription());
            }
        }
    }
}
