namespace img.Analizadores
{
    using Algoritmos.Comun;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAnalizador
    {
        ResultadoDeAnalisisDeFragmento Ejecutar();

        void Configurar(IFragmento fragmento);
    }
}
