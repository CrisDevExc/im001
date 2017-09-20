namespace img.Analizadores.Decorator
{
    using Algoritmos.Comun;
    using Comun;
    using System;
    using System.Drawing;

    public abstract class AnalisisDeSimilitud
    {
        public abstract Func<float> CoeficienteDeSimilitudMimimo { get; set; }

        public abstract Func<Size> TamañoDeContenedorDeBusquedaEnImagen { get; set; }

        public abstract Func<Point> PosicionDelContenedorDeBusquedaEnImagen { get; set; }

        public abstract IFragmento Fragmento { get; set; }

        //public IBitmapWrapper Imagen { get; set; }

        public abstract ResultadoDeAnalisisDeFragmento Ejecutar();
    }
}
