﻿namespace img.Analizadores
{
    using Algoritmos.Comun;
    using Atributos;
    using Decorator;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AnalizadorPorBusquedaExactaEnImagenCompleta : AnalizadorBase, IAnalizadorPorBusquedaExactaEnImagenCompleta
    {
        public AnalizadorPorBusquedaExactaEnImagenCompleta(IDivisorDeImagenCompleta divisorDeContenedor)
        {
            this.DivisorDeContenedor = divisorDeContenedor;
        }

        private IDivisorDeImagenCompleta DivisorDeContenedor { get; set; }

        protected override AnalisisDeSimilitud GenerarAnalisis()
        {
            AnalisisDeSimilitud analisis = new AnalisisDeSimilitudBase();
            AtributoCoeficienteDeSimilitudCasiExacto analisisDecorado1 = new AtributoCoeficienteDeSimilitudCasiExacto();
            AtributoUbicacionCentralRespectoAOriginal analisisDecorado2 = new AtributoUbicacionCentralRespectoAOriginal();
            AtributoContenedorMaximoDeBusqueda analisisDecorado3 = new AtributoContenedorMaximoDeBusqueda(this.DivisorDeContenedor);

            analisisDecorado1.SetComponent(analisis);
            analisisDecorado2.SetComponent(analisisDecorado1);
            analisisDecorado3.SetComponent(analisisDecorado2);

            return analisisDecorado3;
        }
    }
}
