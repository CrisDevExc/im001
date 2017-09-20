namespace img
{
    using System.Collections.Generic;

    public interface IFragmentoPrincipal : IFragmento
    {
        List<IFragmentoRelacionado> ReferenciasAFragmentosDeContexto { get; }

        List<TextoRelacionado> ReferenciasATextoDeContexto { get; }
    }
}