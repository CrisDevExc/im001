namespace img
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    public class FragmentoRelacionado : Fragmento, IFragmentoRelacionado
    {
        #region Propiedades protegidas
        public IFragmento FragmentoPrincipal { get; set; }

        public Rectangle CoordenadasDeZona { get; set; }

        public TipoDeZona Zona { get; set; }

        public int NivelDeCercania { get; set; }

        #endregion

    }
}
