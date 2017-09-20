namespace img.Algoritmos.Comun
{
    using Analizadores;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class BusquedaBase<TAnalizador, TResultado> 
        where TAnalizador: IAnalizador
        where TResultado : ResultadoDeBusqueda, new()
    {
        public BusquedaBase(TAnalizador analizador)
        {
            this.Analizador = analizador;
        }

        protected TAnalizador Analizador { get; set; }

        public ResultadoDeBusqueda Ejecutar(IFragmentoPrincipal fragmentoPrincipal)
        {
            var resultadoFragmentoPrincipal = this.BuscarFragmentoPrincipal(fragmentoPrincipal);
            var resultadosFragmentosRelacionados = this.BuscarFragmentosRelacionados(fragmentoPrincipal, resultadoFragmentoPrincipal);

            var resultado = new TResultado();
            resultado.Configurar(resultadoFragmentoPrincipal, resultadosFragmentosRelacionados);

            return resultado;
        }

        protected virtual ResultadoDeAnalisisDeFragmento BuscarFragmentoPrincipal(IFragmentoPrincipal fragmentoPrincipal)
        {
            this.Analizador.Configurar(fragmentoPrincipal);
            var resultadoFragmentoPrincipal = this.Analizador.Ejecutar();

            return resultadoFragmentoPrincipal;
        }

        protected virtual List<ResultadoDeAnalisisDeFragmento> BuscarFragmentosRelacionados(IFragmentoPrincipal fragmentoPrincipal, ResultadoDeAnalisisDeFragmento resultadoFragmentoPrincipal)
        {
            List<ResultadoDeAnalisisDeFragmento> listaResultados = new List<ResultadoDeAnalisisDeFragmento>();

            fragmentoPrincipal.ReferenciasAFragmentosDeContexto.ForEach(fragmentoDeContexto =>
            {
                this.Analizador.Configurar(fragmentoDeContexto);
                listaResultados.Add(this.Analizador.Ejecutar());
            });

            return listaResultados;
        }
    }
}
