namespace img.Comun
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BitmapWrapper : IBitmapWrapper
    {
        public BitmapWrapper(Bitmap imagen, Point ubicacion)
        {
            this.Imagen = imagen;
            this.Location = ubicacion;
        }

        public int Height
        {
            get
            {
                return this.Imagen.Height;
            }
        }

        public Bitmap Imagen { get; private set; }

        public Size Size
        {
            get
            {
                return this.Imagen.Size;
            }
        }

        public Point Location { get; private set; }

        public int Width
        {
            get
            {
                return this.Imagen.Width;
            }
        }

        public int X
        {
            get
            {
                return this.Location.X;
            }
        }

        public int Y
        {
            get
            {
                return this.Location.Y;
            }
        }
    }
}
