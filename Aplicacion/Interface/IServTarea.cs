using Dominio.Interface;

namespace Aplicacion.Interface
{
    public interface IServTarea<TEntidad, TEntidadID>
        : IInsertar<TEntidad>, IActualizar<TEntidad>, IEliminar<TEntidadID>
    {
        List<TEntidad> ObtenerTodo(string order);

        List<TEntidad> ObtenerPorFiltro(TEntidad entidad, string order);

        TEntidad ObtenerPorID(TEntidadID entidadID, string codTarea, DateTime fechaInicio);
    }
}
