namespace img
{
    using img.Comun;
    using System;

    public interface IFragmento
    {
        Guid Id { get; }

        IBitmapWrapper ImagenContenedoraWrapper { get; }

        IBitmapWrapper ImagenWrapper { get; }
    }
}