using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img.Algoritmos.Comun
{
    public class UbicacionRelacionada
    {
        public UbicacionRelacionada(Rectangle referenciaOriginal, Rectangle referenciaActual, Rectangle elementoRelacionadoOriginal)
        {
            this.ReferenciaOriginal = referenciaOriginal;
            this.ReferenciaActual = referenciaActual;
            this.ElementoRelacionadoOriginal = elementoRelacionadoOriginal;
        }

        private Rectangle ReferenciaOriginal { get; set; }

        private Rectangle ReferenciaActual { get; set; }

        private Rectangle ElementoRelacionadoOriginal { get; set; }

        public Rectangle Calcular()
        {

        }
    }
}
