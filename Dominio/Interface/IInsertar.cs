
namespace Dominio.Interface
{
    public interface IInsertar<TEntidad>
    {
        TEntidad Insertar(TEntidad entidad);
    }
}
