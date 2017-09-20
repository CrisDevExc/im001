namespace img.Analizadores.Atributos
{
    using System;
    using System.Drawing;

    /// <summary>
    /// Establece la ubicación proporcional a la del contenedor mínimo original del fragmento. Debe tener en cuenta los tamaños de la imagen completa
    /// para no exceder los límites.
    /// </summary>
    public class AtributoUbicacionCentralRespectoAOriginal : Decorator.AnalisisDeSimilitudDecorator
    {
        protected override void Configurar()
        {
            this.PosicionDelContenedorDeBusquedaEnImagen = () => this.CalcularUbicacion();
        }

        private Point CalcularUbicacion()
        {
            Point ubicacionOriginal = this.Fragmento.ImagenWrapper.Location;
            int diferenciaDeAnchoRespectoAOriginal = this.TamañoDeContenedorDeBusquedaEnImagen().Width - this.Fragmento.ImagenWrapper.Width;
            int diferenciaDeAltoRespectoAOriginal = this.TamañoDeContenedorDeBusquedaEnImagen().Height - this.Fragmento.ImagenWrapper.Height;

            int ubicacionX = 0;
            int ubicacionY = 0;
            int ubicacionXDeseada = ubicacionOriginal.X - diferenciaDeAnchoRespectoAOriginal / 2;
            int ubicacionYDeseada = ubicacionOriginal.Y - diferenciaDeAltoRespectoAOriginal / 2;

            if (ubicacionXDeseada < 0)
            {
                ubicacionX = 0;
            }
            else if (ubicacionXDeseada + this.TamañoDeContenedorDeBusquedaEnImagen().Width > this.Fragmento.ImagenContenedoraWrapper.Width)
            {
                ubicacionX = this.Fragmento.ImagenContenedoraWrapper.Width - this.TamañoDeContenedorDeBusquedaEnImagen().Width;
            }
            else
            {
                ubicacionX = ubicacionXDeseada;
            }
            
            if (ubicacionYDeseada < 0)
            {
                ubicacionY = 0;
            }
            else if (ubicacionYDeseada + this.TamañoDeContenedorDeBusquedaEnImagen().Height > this.Fragmento.ImagenContenedoraWrapper.Height)
            {
                ubicacionY = this.Fragmento.ImagenContenedoraWrapper.Height - this.TamañoDeContenedorDeBusquedaEnImagen().Height;
            }
            else
            {
                ubicacionY = ubicacionYDeseada;
            }

            return new Point(ubicacionX, ubicacionY);
        }
    }
}
