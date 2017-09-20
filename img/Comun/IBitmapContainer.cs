namespace img.Comun
{
    using System.Drawing;

    public interface IBitmapContainer
    {
        Size Size { get; }

        Point Location { get; }

        int Height { get; }

        int Width { get; }

        int X { get; }

        int Y { get; }
    }
}