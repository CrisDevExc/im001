namespace img.Analizadores
{
    using Algoritmos.Comun;
    using Comun;
    using Decorator;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class AnalizadorBase
    {
        private AnalisisDeSimilitud analisis;

        public void Configurar(IFragmento fragmento)
        {
            this.Analisis.Fragmento = fragmento;
        }

        public ResultadoDeAnalisisDeFragmento Ejecutar()
        {
            return this.Analisis.Ejecutar();
        }

        private AnalisisDeSimilitud Analisis
        {
            get
            {
                return LazyInitializer.EnsureInitialized(ref this.analisis, () => this.GenerarAnalisis());
            }
        }

        protected abstract AnalisisDeSimilitud GenerarAnalisis();
    }
}
