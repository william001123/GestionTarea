
namespace Dominio.Interface.Repositorio
{
    public interface IRepoAutenticacion<TEntidad, TEntidadID>
        : IInsertar<TEntidad>, ISalvarTodo
    {
        TEntidad ObtenerAutenticacion(TEntidadID Usuario, TEntidadID Contrasena);
    }
}
