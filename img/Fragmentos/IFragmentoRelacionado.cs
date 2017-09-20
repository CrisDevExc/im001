namespace img
{
    using System.Drawing;

    public interface IFragmentoRelacionado : IFragmento
    {
        IFragmento FragmentoPrincipal { get; }

        Rectangle CoordenadasDeZona { get; }

        TipoDeZona Zona { get; }

        int NivelDeCercania { get; }
    }
}