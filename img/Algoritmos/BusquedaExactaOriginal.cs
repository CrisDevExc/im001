namespace img.Algoritmos
{
    using Analizadores;
    using Comun;
    using Resultados;
    using System.Linq;

    public class BusquedaExactaOriginal : BusquedaBase<IAnalizadorPorBusquedaExactaOriginal, ResultadoDeBusquedaExactaOriginal>, IBusqueda
    {
        public BusquedaExactaOriginal(IAnalizadorPorBusquedaExactaOriginal analizador) : base(analizador)
        {
        }        
    }
}
