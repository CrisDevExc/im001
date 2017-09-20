namespace img
{
    using AForge.Imaging;
    using Algoritmos.Comun;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    public class ResultadoDeAnalisisDeFragmento
    {
        #region Propiedades públicas
        public IFragmento Fragmento { get; set; }

        public Rectangle ContenedorDeBusquedaEnImagen { get; set; }

        public List<TemplateMatch> Coincidencias { get; set; }
        #endregion
    }
}
