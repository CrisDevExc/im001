namespace img.Analizadores.Atributos
{
    using Algoritmos.Comun;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class AtributoContenedorMaximoDeBusqueda : Decorator.AnalisisDeSimilitudDecorator
    {
        public AtributoContenedorMaximoDeBusqueda(IDivisorDeImagenCompleta divisorDeContenedor)
        {
            this.DivisorDeContenedor = divisorDeContenedor;
        }

        private IDivisorDeImagenCompleta DivisorDeContenedor { get; set; }

        protected override void Configurar()
        {
        }

        public override ResultadoDeAnalisisDeFragmento Ejecutar()
        {
            List<Rectangle> contenedores = this.DivisorDeContenedor.GenerarColeccionDeContenedores(this.Fragmento);
            List<ResultadoDeAnalisisDeFragmento> resultados = new List<ResultadoDeAnalisisDeFragmento>();
            contenedores.ForEach(contenedor =>
            {
                this.TamañoDeContenedorDeBusquedaEnImagen = () => contenedor.Size;
                this.PosicionDelContenedorDeBusquedaEnImagen = () => contenedor.Location;
                resultados.Add(base.Ejecutar());
            });

            return resultados.OrderByDescending(x => x.Coincidencias.Max(c => c.Similarity)).First();
        }
    }
}
