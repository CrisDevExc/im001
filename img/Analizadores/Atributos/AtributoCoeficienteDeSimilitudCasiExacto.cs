namespace img.Analizadores.Atributos
{
    using img.Analizadores.Decorator;

    public class AtributoCoeficienteDeSimilitudCasiExacto : AnalisisDeSimilitudDecorator
    {
        protected override void Configurar()
        {
            this.CoeficienteDeSimilitudMimimo = () => 0.95f;
        }
    }
}
