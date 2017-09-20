namespace img.Analizadores.Decorator
{
    using Algoritmos.Comun;
    using System;
    using System.Drawing;

    public abstract class AnalisisDeSimilitudDecorator : AnalisisDeSimilitud
    {
        protected AnalisisDeSimilitud component;

        public override Func<float> CoeficienteDeSimilitudMimimo
        {
            get
            {
                return this.component.CoeficienteDeSimilitudMimimo;
            }

            set
            {
                this.component.CoeficienteDeSimilitudMimimo = value;
            }
        }

        public override Func<Size> TamañoDeContenedorDeBusquedaEnImagen
        {
            get
            {
                return this.component.TamañoDeContenedorDeBusquedaEnImagen;
            }

            set
            {
                this.component.TamañoDeContenedorDeBusquedaEnImagen = value;
            }
        }

        public override Func<Point> PosicionDelContenedorDeBusquedaEnImagen
        {
            get
            {
                return this.component.PosicionDelContenedorDeBusquedaEnImagen;
            }

            set
            {
                this.component.PosicionDelContenedorDeBusquedaEnImagen = value;
            }
        }

        public override IFragmento Fragmento
        {
            get
            {
                return this.component.Fragmento;
            }

            set
            {
                this.component.Fragmento = value;
            }
        }

        protected abstract void Configurar();

        public override ResultadoDeAnalisisDeFragmento Ejecutar()
        {
            this.Configurar();
            return this.component.Ejecutar();
        }

        public void SetComponent(AnalisisDeSimilitud component)
        {
            this.component = component;
        }
    }
}
