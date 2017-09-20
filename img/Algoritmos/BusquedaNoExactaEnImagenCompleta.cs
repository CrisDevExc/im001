namespace img.Algoritmos
{
    using Comun;
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

    public class BusquedaNoExactaEnImagenCompleta : BusquedaBase<IAnalizadorPorBusquedaNoExactaEnImagenCompleta, ResultadoDeBusquedaNoExactaEnImagenCompleta>, IBusqueda
    {
        public BusquedaNoExactaEnImagenCompleta(IAnalizadorPorBusquedaNoExactaEnImagenCompleta analizador) : base(analizador)
        {
        }
    }
}