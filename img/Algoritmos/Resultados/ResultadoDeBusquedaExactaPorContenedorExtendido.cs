namespace img.Algoritmos.Resultados
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ResultadoDeBusquedaExactaPorContenedorExtendido : ResultadoDeBusqueda
    {
        public override bool Positivo
        {
            get
            {
                return this.PositivoFragmentoPrincipal && this.PositivosPorZona.Count(x => x.Value) >= 3;
            }
        }
    }
}
