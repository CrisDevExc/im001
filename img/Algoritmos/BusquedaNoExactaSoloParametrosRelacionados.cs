namespace img.Algoritmos
{
    using Comun;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    using System.Threading;
    using Analizadores;
    using img.Comun;
    using Resultados;

    public class BusquedaNoExactaSoloParametrosRelacionados : BusquedaBase<IAnalizadorPorBusquedaNoExactaOriginal, ResultadoDeBusquedaNoExactaSoloParametrosRelacionados>, IBusqueda
    {
        public BusquedaNoExactaSoloParametrosRelacionados(IAnalizadorPorBusquedaNoExactaOriginal analizador) : base(analizador)
        {
        }
    }
}