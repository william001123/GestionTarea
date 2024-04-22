
namespace Dominio.Interface
{
    public interface IListar<TEntidad, TEntidadID>
    {
        List<TEntidad> ObtenerTodo();

        TEntidad ObtenerPorID(TEntidadID entidadID);
    }
}
