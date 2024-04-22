using Dominio.Interface;

namespace Aplicacion.Interface
{
    public interface IServAutenticacion<TEntidad, TEntidadID>
        : IInsertar<TEntidad>
    {
        TEntidad ObtenerAutenticacion(TEntidadID Usuario, TEntidadID Contrasena);

        string Token(TEntidadID Usuario);
    }
}
