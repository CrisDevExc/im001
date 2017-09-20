namespace img.Algoritmos
{
    using Analizadores;
    using Comun;
    using Resultados;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class BusquedaExactaEnImagenCompleta : BusquedaBase<IAnalizadorPorBusquedaExactaOriginal, ResultadoDeBusquedaExactaEnImagenCompleta>, IBusqueda
    {
        public BusquedaExactaEnImagenCompleta(IAnalizadorPorBusquedaExactaOriginal analizador) : base(analizador)
        {
        }

        protected override List<ResultadoDeAnalisisDeFragmento> BuscarFragmentosRelacionados(IFragmentoPrincipal fragmentoPrincipal, ResultadoDeAnalisisDeFragmento resultadoFragmentoPrincipal)
        {
            return base.BuscarFragmentosRelacionados(fragmentoPrincipal, resultadoFragmentoPrincipal);
        }

        //protected override ResultadoDeAnalisisDeFragmento BuscarFragmentoPrincipal(IFragmentoPrincipal fragmentoPrincipal)
        //{
        //    List<Rectangle> contenedores = this.DivisorDeContenedor.GenerarColeccionDeContenedores(fragmentoPrincipal);
        //    contenedores.ForEach(contenedor =>
        //    {
        //        var fragmentoWrapper = new FragmentoParaAnalisisWrapper(fragmentoPrincipal, contenedor.Location, contenedor.Size);

        //    //this.Analizador.Configurar(fragmentoPrincipal);
        //        var resultadoFragmentoPrincipal = this.Analizador.Ejecutar();
        //    });


        //    return resultadoFragmentoPrincipal;
        //}
    }
}
