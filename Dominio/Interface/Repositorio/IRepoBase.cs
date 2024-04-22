
namespace Dominio.Interface.Repositorio
{
    public interface IRepoBase<TEntidad, TEntidadID>
        : IInsertar<TEntidad>, IActualizar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, ISalvarTodo
    {
    }
}
