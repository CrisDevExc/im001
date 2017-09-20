namespace img.Analizadores.Decorator
{
    using AForge.Imaging;
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using System;
    using ProcesamientoDeImagen;
    using Algoritmos.Comun;

    public class AnalisisDeSimilitudBase : AnalisisDeSimilitud
    {
        private IProcesador procesador;
        private Func<float> coeficienteDeSimilitudMimimo;
        private Func<Size> tamañoDeContenedorDeBusquedaEnImagen;
        private Func<Point> posicionDelContenedorDeBusquedaEnImagen;

        private IProcesador Procesador
        {
            get
            {
                return LazyInitializer.EnsureInitialized(ref this.procesador, () => new Procesador() { SimilarityThreshold = this.CoeficienteDeSimilitudMimimo() });
            }
        }

        private Rectangle ContenedorDeBusquedaEnImagen
        {
            get
            {
                return new Rectangle(this.PosicionDelContenedorDeBusquedaEnImagen(), this.TamañoDeContenedorDeBusquedaEnImagen());
            }
        }


        public override Func<float> CoeficienteDeSimilitudMimimo
        {
            get
            {
                if(this.coeficienteDeSimilitudMimimo == null)
                {
                    this.coeficienteDeSimilitudMimimo =  () => 0.99f;
                }

                return this.coeficienteDeSimilitudMimimo;
            }

            set
            {
                this.coeficienteDeSimilitudMimimo = value;
            }
        }

        public override Func<Size> TamañoDeContenedorDeBusquedaEnImagen
        {
            get
            {
                if(this.tamañoDeContenedorDeBusquedaEnImagen == null)
                {
                    this.tamañoDeContenedorDeBusquedaEnImagen = () => this.Fragmento.ImagenWrapper.Size;
                }

                return this.tamañoDeContenedorDeBusquedaEnImagen;
            }

            set
            {
                this.tamañoDeContenedorDeBusquedaEnImagen = value;
            }
        }

        public override Func<Point> PosicionDelContenedorDeBusquedaEnImagen
        {
            get
            {
                if(this.posicionDelContenedorDeBusquedaEnImagen == null)
                {
                    this.posicionDelContenedorDeBusquedaEnImagen = () => this.Fragmento.ImagenWrapper.Location;
                }

                return this.posicionDelContenedorDeBusquedaEnImagen;
            }

            set
            {
                this.posicionDelContenedorDeBusquedaEnImagen = value;
            }
        }

        public override IFragmento Fragmento { get; set; }

        public override ResultadoDeAnalisisDeFragmento Ejecutar()
        {
            if (this.TamañoDeContenedorDeBusquedaEnImagen().Width == 0)
            {
                Rectangle limites = new Rectangle(this.PosicionDelContenedorDeBusquedaEnImagen(), this.TamañoDeContenedorDeBusquedaEnImagen());
            }

            // find all matchings with specified above similarity
            TemplateMatch[] matchings = null;
            this.Procesador.SimilarityThreshold = 0.99f;

            while (matchings == null || matchings.Count() == 0)
            {
                matchings = this.Procesador.ProcessImage(this.Fragmento.ImagenContenedoraWrapper.Imagen, this.Fragmento.ImagenWrapper.Imagen, this.ContenedorDeBusquedaEnImagen);
                if (matchings.Count() > 0 || this.Procesador.SimilarityThreshold < this.CoeficienteDeSimilitudMimimo())
                {
                    break;
                }

                this.Procesador.SimilarityThreshold -= 0.02f;
            }

            ResultadoDeAnalisisDeFragmento resultado = new ResultadoDeAnalisisDeFragmento();
            resultado.Coincidencias = matchings.ToList();
            resultado.Fragmento = this.Fragmento;
            resultado.ContenedorDeBusquedaEnImagen = this.ContenedorDeBusquedaEnImagen;

            return resultado;
        }
    }
}
