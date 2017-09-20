namespace img.Analizadores.Atributos
{
    using img.Analizadores.Decorator;

    public class AtributoCoeficienteDeSimilitudExacto : AnalisisDeSimilitudDecorator
    {
        protected override void Configurar()
        {
            this.CoeficienteDeSimilitudMimimo = () => 0.99f;
        }
    }
}
