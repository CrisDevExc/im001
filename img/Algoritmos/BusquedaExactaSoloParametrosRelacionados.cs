namespace img.Algoritmos
{
    using Analizadores;
    using Comun;
    using Resultados;
    using System.Linq;

    public class BusquedaExactaSoloParametrosRelacionados : BusquedaBase<IAnalizadorPorBusquedaExactaOriginal, ResultadoDeBusquedaNoExactaSoloParametrosRelacionados>, IBusqueda
    {
        public BusquedaExactaSoloParametrosRelacionados(IAnalizadorPorBusquedaExactaOriginal analizador) : base(analizador)
        {
        }
    }
}
