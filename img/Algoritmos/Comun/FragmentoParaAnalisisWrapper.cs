namespace img.Algoritmos.Comun
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FragmentoParaAnalisisWrapper : IFragmentoParaAnalisisWrapper
    {
        private Size size;
        private Point location;
        private Bitmap imagenContenedora;
        private Bitmap imagen;

        public FragmentoParaAnalisisWrapper(IFragmento fragmento)
        {
            this.Fragmento = fragmento;
        }

        public FragmentoParaAnalisisWrapper(IFragmento fragmento, Point ubicacionContenedor, Size tamañoContenedor) : this(fragmento)
        {
            this.size = tamañoContenedor;
            this.location = ubicacionContenedor;
        }

        public IFragmento Fragmento { get; private set; }

        public Bitmap Imagen
        {
            get
            {
                if (this.imagen == null)
                {
                    this.imagen = this.Fragmento.ImagenWrapper.Imagen;
                }

                return this.imagen;
            }
        }

        public Bitmap ImagenContenedora
        {
            get
            {
                if (this.imagenContenedora == null)
                {
                    this.imagenContenedora = this.Fragmento.ImagenContenedoraWrapper.Imagen;
                }

                return this.imagenContenedora;
            }
        }

        public Size Size
        {
            get
            {
                if (this.size == null)
                {
                    this.size = this.Fragmento.ImagenWrapper.Size;
                }

                return this.size;
            }
        }

        public Point Location
        {
            get
            {
                if (this.location == null)
                {
                    this.location = this.Fragmento.ImagenWrapper.Location;
                }

                return this.location;
            }
        }
    }
}
