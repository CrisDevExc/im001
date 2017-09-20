namespace img.Algoritmos
{
    using Comun;
    using img.Analizadores.Atributos;
    using img.Analizadores.Decorator;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    using Analizadores;
    using System.Threading;
    using img.Comun;
    using Resultados;

    public class BusquedaExactaPorContenedorExtendido : BusquedaBase<IAnalizadorPorBusquedaExactaEnContenedorExtendido, ResultadoDeBusquedaExactaPorContenedorExtendido>, IBusqueda
    {
        public BusquedaExactaPorContenedorExtendido(IAnalizadorPorBusquedaExactaEnContenedorExtendido analizador) : base(analizador)
        {
        }
    }
}
