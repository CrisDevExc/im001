namespace img
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class ResultadoDeBusqueda
    {
        public ResultadoDeBusqueda()
        {
            this.Inicializar();
        }

        public abstract bool Positivo { get; }

        public bool PositivoFragmentoPrincipal { get; set; }

        public Dictionary<TipoDeZona, bool> PositivosPorZona { get; set; }

        public Dictionary<int, bool> PositivosPorNivelDeCercania { get; set; }

        private void Inicializar()
        {
            this.PositivosPorZona = new Dictionary<TipoDeZona, bool>();
            this.PositivosPorNivelDeCercania = new Dictionary<int, bool>();

            this.PositivosPorZona.Add(TipoDeZona.CuadranteInferiorDerecho, false);
            this.PositivosPorZona.Add(TipoDeZona.CuadranteInferiorIzquierdo, false);
            this.PositivosPorZona.Add(TipoDeZona.CuadranteSuperiorDerecho, false);
            this.PositivosPorZona.Add(TipoDeZona.CuadranteSuperiorIzquierdo, false);
            this.PositivosPorZona.Add(TipoDeZona.FranjaXNegativa, false);
            this.PositivosPorZona.Add(TipoDeZona.FranjaXPositiva, false);
            this.PositivosPorZona.Add(TipoDeZona.FranjaYNegativa, false);
            this.PositivosPorZona.Add(TipoDeZona.FranjaYPositiva, false);

            this.PositivosPorNivelDeCercania.Add(0, false);
            this.PositivosPorNivelDeCercania.Add(1, false);
            this.PositivosPorNivelDeCercania.Add(2, false);
            this.PositivosPorNivelDeCercania.Add(3, false);
            this.PositivosPorNivelDeCercania.Add(4, false);
        }

        public void Configurar(ResultadoDeAnalisisDeFragmento resultadoFragmentoPrincipal, List<ResultadoDeAnalisisDeFragmento> resultadosFragmentosRelacionados)
        {
            this.PositivoFragmentoPrincipal = resultadoFragmentoPrincipal.Coincidencias.Count() > 0;
            resultadosFragmentosRelacionados.ForEach(resultadoFragmento =>
            {
                if (resultadoFragmento.Coincidencias.Count > 0)
                {
                    this.PositivosPorNivelDeCercania[((IFragmentoRelacionado)resultadoFragmento.Fragmento).NivelDeCercania] = true;
                    this.PositivosPorZona[((IFragmentoRelacionado)resultadoFragmento.Fragmento).Zona] = true;
                }
            });
        }
    }
}
