namespace img.ProcesamientoDeImagen
{
    using AForge.Imaging;

    public interface IProcesador : ITemplateMatching
    {
        float SimilarityThreshold { get; set; }
    }
}