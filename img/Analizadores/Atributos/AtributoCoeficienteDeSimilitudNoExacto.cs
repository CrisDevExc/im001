namespace img.Analizadores.Atributos
{
    using System;
    using img.Analizadores.Decorator;

    public class AtributoCoeficienteDeSimilitudNoExacto : AnalisisDeSimilitudDecorator
    {
        protected override void Configurar()
        {
            this.CoeficienteDeSimilitudMimimo = () =>  0.80f;
        }
    }
}
