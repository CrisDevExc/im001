namespace img.Algoritmos.Comun
{
    using img.Comun;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Threading;

    public class DivisorDeImagenCompleta : IDivisorDeImagenCompleta
    {
        private IBitmapWrapper imagenCompleta;
        private IFragmentoParaAnalisisWrapper fragmentoPrincipal;

        public List<Rectangle> GenerarColeccionDeContenedores(IFragmentoParaAnalisisWrapper fragmentoWrapper)
        {
            this.fragmentoPrincipal = fragmentoWrapper;
            this.imagenCompleta = fragmentoWrapper.ImagenContenedoraWrapper;
            Size tamañoContenedor = this.CalcularTamañoDeContenedor();

            int posicionX = 0;
            int posicionY = 0;
            bool finalDeImagenY = false;
            bool areaCubierta = false;
            List<Rectangle> contenedores = new List<Rectangle>();

            while (!areaCubierta)
            {
                Rectangle contenedor = new Rectangle(new Point(posicionX, posicionY), tamañoContenedor);
                contenedores.Add(contenedor);
                posicionX = posicionX + tamañoContenedor.Width / 2;
                if (posicionX > this.imagenCompleta.Width)
                {
                    posicionX = this.imagenCompleta.Width - tamañoContenedor.Width;
                    
                    if (!finalDeImagenY)
                    {
                        posicionY = posicionY + tamañoContenedor.Height / 2;
                        if (posicionY > this.imagenCompleta.Height)
                        {
                            posicionY = this.imagenCompleta.Height - tamañoContenedor.Height;
                            finalDeImagenY = true;
                        }
                    }
                    else
                    {
                        areaCubierta = true;
                    }
                }
            }

            return contenedores;
        }

        private Size CalcularTamañoDeContenedor()
        {
            int anchoPorDerechaDesdeElCentro = this.fragmentoPrincipal.ReferenciasAFragmentosDeContexto
                                        .Where(x => x.ImagenWrapper.X > x.FragmentoPrincipal.ImagenWrapper.X + x.FragmentoPrincipal.ImagenWrapper.Width)
                                        .Max(x => ((x.ImagenWrapper.X + x.ImagenWrapper.Width) - (x.FragmentoPrincipal.ImagenWrapper.X + x.FragmentoPrincipal.ImagenWrapper.Width) / 2));
            int anchoPorIzquierdaDesdeElCentro = this.fragmentoPrincipal.ReferenciasAFragmentosDeContexto
                                        .Where(x => x.ImagenWrapper.X + x.ImagenWrapper.Width < x.FragmentoPrincipal.ImagenWrapper.X)
                                        .Max(x => ((x.FragmentoPrincipal.ImagenWrapper.X + x.FragmentoPrincipal.ImagenWrapper.Width) / 2) - (x.ImagenWrapper.X + x.ImagenWrapper.Width));

            int altoPorDebajoDesdeElCentro = this.fragmentoPrincipal.ReferenciasAFragmentosDeContexto
                                        .Where(x => x.ImagenWrapper.Y > x.FragmentoPrincipal.ImagenWrapper.Y + x.FragmentoPrincipal.ImagenWrapper.Height)
                                        .Max(x => ((x.ImagenWrapper.Y + x.ImagenWrapper.Height) - (x.FragmentoPrincipal.ImagenWrapper.Y + x.FragmentoPrincipal.ImagenWrapper.Height) / 2));
            int altoPorArribaDesdeElCentro = this.fragmentoPrincipal.ReferenciasAFragmentosDeContexto
                                        .Where(x => x.ImagenWrapper.Y + x.ImagenWrapper.Height < x.FragmentoPrincipal.ImagenWrapper.Y)
                                        .Max(x => ((x.FragmentoPrincipal.ImagenWrapper.Y + x.FragmentoPrincipal.ImagenWrapper.Height) / 2) - (x.ImagenWrapper.Y + x.ImagenWrapper.Height));

            int alto = (altoPorArribaDesdeElCentro >= altoPorDebajoDesdeElCentro ? altoPorArribaDesdeElCentro : altoPorDebajoDesdeElCentro) * 2;
            int ancho = (anchoPorDerechaDesdeElCentro >= anchoPorIzquierdaDesdeElCentro ? anchoPorDerechaDesdeElCentro : anchoPorIzquierdaDesdeElCentro) * 2;

            return new Size(ancho, alto);
        }
    }
}
