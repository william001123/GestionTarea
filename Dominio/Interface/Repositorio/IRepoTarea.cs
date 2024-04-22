
namespace Dominio.Interface.Repositorio
{
    public interface IRepoTarea<TEntidad, TEntidadID>
        : IInsertar<TEntidad>, IActualizar<TEntidad>, IEliminar<TEntidadID>, ISalvarTodo
    {
        List<TEntidad> ObtenerTodo(string order);

        List<TEntidad> ObtenerPorFiltro(TEntidad entidad, string order);

        TEntidad ObtenerPorID(TEntidadID entidadID, string codTarea, DateTime fechaInicio);
    }
}
