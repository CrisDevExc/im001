namespace img.Analizadores
{
    using Atributos;
    using Decorator;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AnalizadorPorBusquedaNoExactaOriginal : AnalizadorBase, IAnalizadorPorBusquedaNoExactaOriginal
    {
        protected override AnalisisDeSimilitud GenerarAnalisis()
        {
            AnalisisDeSimilitud analisis = new AnalisisDeSimilitudBase();
            AtributoCoeficienteDeSimilitudNoExacto analisisDecorado1 = new AtributoCoeficienteDeSimilitudNoExacto();
            AtributoContenedorDeBusquedaTamañoX analisisDecorado2 = new AtributoContenedorDeBusquedaTamañoX(1);
            AtributoUbicacionCentralRespectoAOriginal analisisDecorado3 = new AtributoUbicacionCentralRespectoAOriginal();
            analisisDecorado1.SetComponent(analisis);
            analisisDecorado2.SetComponent(analisisDecorado1);
            analisisDecorado3.SetComponent(analisisDecorado2);

            return analisisDecorado3;
        }
    }
}
