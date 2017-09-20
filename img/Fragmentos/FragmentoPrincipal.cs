namespace img
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FragmentoPrincipal : Fragmento, IFragmentoPrincipal
    {
        public FragmentoPrincipal()
        {
            this.ReferenciasAFragmentosDeContexto = new List<IFragmentoRelacionado>();
        }

        #region Propiedades protegidas
        public List<IFragmentoRelacionado> ReferenciasAFragmentosDeContexto { get; set; }

        public List<TextoRelacionado> ReferenciasATextoDeContexto { get; set; }
        #endregion
    }
}
