namespace img.Comun
{
    using System.Drawing;

    public interface IBitmapWrapper : IBitmapContainer
    {
        Bitmap Imagen { get; }
    }
}
