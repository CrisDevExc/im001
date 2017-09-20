namespace img.Analizadores.Atributos
{
    using System;
    using System.Drawing;

    public class AtributoContenedorDeBusquedaTamañoX : Decorator.AnalisisDeSimilitudDecorator
    {
        private decimal coeficienteDeTamaño;
        public AtributoContenedorDeBusquedaTamañoX(decimal coeficiente)
        {
            this.coeficienteDeTamaño = coeficiente;
        }

        protected override void Configurar()
        {
            this.TamañoDeContenedorDeBusquedaEnImagen = () => this.Calcular();
        }

        private Size Calcular()
        {
            int anchoDeseado = (int)(base.TamañoDeContenedorDeBusquedaEnImagen().Width * this.coeficienteDeTamaño);
            int altoDeseado = (int)(base.TamañoDeContenedorDeBusquedaEnImagen().Height * this.coeficienteDeTamaño);
            int ancho = anchoDeseado > this.Fragmento.ImagenContenedoraWrapper.Width ? this.Fragmento.ImagenContenedoraWrapper.Width : anchoDeseado;
            int alto = altoDeseado > this.Fragmento.ImagenContenedoraWrapper.Height ? this.Fragmento.ImagenContenedoraWrapper.Height : altoDeseado;

            return new Size(ancho, alto);
        }
    }
}
