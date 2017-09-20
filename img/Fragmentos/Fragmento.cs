namespace img
{
    using Comun;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    public class Fragmento: IFragmento
    {
        #region Propiedades públicas
        public Guid Id { get; set; }

        public IBitmapWrapper ImagenContenedoraWrapper { get; set; }

        public IBitmapWrapper ImagenWrapper { get; set; }
        #endregion
    }
}
