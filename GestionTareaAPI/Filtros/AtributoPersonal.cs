namespace GestionTareaAPI.Filtros
{
    public class AtributoPersonal
    {
        public readonly bool ContainsAttribute;
        public readonly bool Mandatory;

        public AtributoPersonal(bool _ContainsAttribute, bool _Mandatory)
        {
            ContainsAttribute = _ContainsAttribute;
            Mandatory = _Mandatory;
        }
    }
}
