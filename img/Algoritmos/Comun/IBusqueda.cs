namespace img.Algoritmos.Comun
{
    using img.Comun;
    using System.Drawing;

    public interface IBusqueda
    {
        ResultadoDeBusqueda Ejecutar(IFragmentoPrincipal fragmentoPrincipal);
    }
}
