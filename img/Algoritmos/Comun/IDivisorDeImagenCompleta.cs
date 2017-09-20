namespace img.Algoritmos.Comun
{
    using System.Collections.Generic;
    using System.Drawing;

    public interface IDivisorDeImagenCompleta
    {
        List<Rectangle> GenerarColeccionDeContenedores(IFragmento fragmentoPrincipal);
    }
}