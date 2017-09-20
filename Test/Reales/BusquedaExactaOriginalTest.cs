using img;
using img.Algoritmos;
using img.Analizadores;
using img.Comun;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Comun;

namespace Test.Reales
{
    [TestClass]
    public class BusquedaExactaOriginalTest
    {
        [TestMethod]
        public void BusquedaExactaOriginal()
        {
            BusquedaExactaOriginal busqueda = new BusquedaExactaOriginal(new AnalizadorPorBusquedaExactaOriginal());
            FragmentoPrincipal fragmentoPrincipal = new FragmentoPrincipal();
            FragmentoRelacionado fragmentoRelacionado = new FragmentoRelacionado();

            Bitmap imagenCompleta = HerramientasDeImagen.CapturarPantalla();
            Bitmap imagenFragmentoPrincipal = HerramientasDeImagen.CortarFragmento(imagenCompleta, new Point(400, 400), new Size(30, 30));
            Bitmap imagenFragmentoRelacionado = HerramientasDeImagen.CortarFragmento(imagenCompleta, new Point(400, 500), new Size(30, 30));

            fragmentoRelacionado.ImagenContenedoraWrapper = new BitmapWrapper(imagenCompleta, new Point());
            fragmentoRelacionado.ImagenWrapper = new BitmapWrapper(imagenFragmentoRelacionado, new Point(400, 500));

            fragmentoPrincipal.ImagenContenedoraWrapper = new BitmapWrapper(imagenCompleta, new Point());
            fragmentoPrincipal.ImagenWrapper = new BitmapWrapper(imagenFragmentoPrincipal, new Point(400, 400));
            fragmentoPrincipal.ReferenciasAFragmentosDeContexto.Add(fragmentoRelacionado);

            var resultado = busqueda.Ejecutar(fragmentoPrincipal);
        }

        //[TestMethod]
        //public void BusquedaExactaEnImagenCompleta()
        //{
        //    BusquedaExactaEnImagenCompleta busqueda = new BusquedaExactaEnImagenCompleta(new AnalizadorPorBusquedaExactaEnImagenCompleta());
        //    FragmentoPrincipal fragmentoPrincipal = new FragmentoPrincipal();
        //    FragmentoRelacionado fragmentoRelacionado = new FragmentoRelacionado();

        //    Bitmap imagenCompleta = HerramientasDeImagen.CapturarPantalla();
        //    Bitmap imagenFragmentoPrincipal = HerramientasDeImagen.CortarFragmento(imagenCompleta, new Point(400, 400), new Size(30, 30));
        //    Bitmap imagenFragmentoRelacionado = HerramientasDeImagen.CortarFragmento(imagenCompleta, new Point(400, 500), new Size(30, 30));

        //    fragmentoRelacionado.ImagenContenedoraWrapper = new BitmapWrapper(imagenCompleta, new Point());
        //    fragmentoRelacionado.ImagenWrapper = new BitmapWrapper(imagenFragmentoRelacionado, new Point(700, 500));

        //    fragmentoPrincipal.ImagenContenedoraWrapper = new BitmapWrapper(imagenCompleta, new Point());
        //    fragmentoPrincipal.ImagenWrapper = new BitmapWrapper(imagenFragmentoPrincipal, new Point(700, 400));
        //    fragmentoPrincipal.ReferenciasAFragmentosDeContexto.Add(fragmentoRelacionado);

        //    var resultado = busqueda.Ejecutar(fragmentoPrincipal);
        //}
    }
}
