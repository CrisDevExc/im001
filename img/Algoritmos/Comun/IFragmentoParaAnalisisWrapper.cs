namespace img.Algoritmos.Comun
{
    using img.Comun;
    using System.Drawing;

    public interface IFragmentoParaAnalisisWrapper
    {
        IBitmapWrapper Imagen { get; }

        IBitmapWrapper ImagenContenedora { get; }

        Size Size { get; }

        Point Location { get; }
    }
}