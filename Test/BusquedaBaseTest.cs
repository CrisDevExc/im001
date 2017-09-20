namespace Test
{
    using AForge.Imaging;
    using img;
    using img.Algoritmos;
    using img.Algoritmos.Comun;
    using img.Algoritmos.Resultados;
    using img.Analizadores;
    using img.Comun;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class BusquedaBaseTest
    {
        [TestMethod]
        public void TodosLosResultadosDebenSerNegativosPorCompleto()
        {
            Mock<IAnalizador> mockAnalizador = new Mock<IAnalizador>();
            Mock<IFragmento> mockFragmentoAnalisis = new Mock<IFragmento>();
            Mock<IFragmentoPrincipal> mockFragmentoPrincipal = new Mock<IFragmentoPrincipal>();
            Mock<IFragmentoRelacionado> mockFragmentoRelacionado = new Mock<IFragmentoRelacionado>();
            Mock<IBitmapWrapper> mockImagenContenedora = new Mock<IBitmapWrapper>();
            Mock<IBitmapWrapper> mockImagen = new Mock<IBitmapWrapper>();
            ResultadoDeAnalisisDeFragmento resultado = new ResultadoDeAnalisisDeFragmento();

            resultado.Coincidencias = new List<TemplateMatch>();
            resultado.Fragmento = mockFragmentoAnalisis.Object;

            mockFragmentoPrincipal.SetupGet(x => x.ReferenciasAFragmentosDeContexto).Returns(new List<IFragmentoRelacionado>() { mockFragmentoRelacionado.Object });
            mockFragmentoPrincipal.SetupGet(x => x.ImagenContenedoraWrapper).Returns(mockImagenContenedora.Object);
            mockFragmentoPrincipal.SetupGet(x => x.ImagenWrapper).Returns(mockImagen.Object);
            mockFragmentoRelacionado.SetupGet(x => x.ImagenContenedoraWrapper).Returns(mockImagenContenedora.Object);
            mockFragmentoRelacionado.SetupGet(x => x.ImagenWrapper).Returns(mockImagen.Object);

            mockAnalizador.Setup(x => x.Configurar(It.IsAny<IFragmento>()));
            mockAnalizador.Setup(x => x.Ejecutar()).Returns(resultado);

            var busqueda = new Mock<BusquedaBase<IAnalizador, ResultadoDeBusquedaExactaOriginal>>(mockAnalizador.Object) { CallBase = true }.Object;
            var resultadoEjecutar = busqueda.Ejecutar(mockFragmentoPrincipal.Object);

            Assert.IsNotNull(resultadoEjecutar);
            Assert.IsFalse(resultadoEjecutar.Positivo);
            Assert.IsFalse(resultadoEjecutar.PositivoFragmentoPrincipal);
            Assert.IsTrue(resultadoEjecutar.PositivosPorNivelDeCercania.All(x => x.Value == false));
            Assert.IsTrue(resultadoEjecutar.PositivosPorZona.All(x => x.Value == false));
        }

        [TestMethod]
        public void PositivoFragmentoPrincipal_CercaniaNivel_Zona_TodosTrue()
        {
            Mock<IAnalizador> mockAnalizador = new Mock<IAnalizador>();
            Mock<IFragmento> mockFragmentoAnalisis = new Mock<IFragmento>();
            Mock<IFragmentoPrincipal> mockFragmentoPrincipal = new Mock<IFragmentoPrincipal>();
            Mock<IFragmentoRelacionado> mockFragmentoRelacionado0 = new Mock<IFragmentoRelacionado>();
            Mock<IFragmentoRelacionado> mockFragmentoRelacionado1 = new Mock<IFragmentoRelacionado>();
            Mock<IFragmentoRelacionado> mockFragmentoRelacionado2 = new Mock<IFragmentoRelacionado>();
            Mock<IFragmentoRelacionado> mockFragmentoRelacionado3 = new Mock<IFragmentoRelacionado>();
            Mock<IFragmentoRelacionado> mockFragmentoRelacionado4 = new Mock<IFragmentoRelacionado>();
            Mock<IFragmentoRelacionado> mockFragmentoRelacionado5 = new Mock<IFragmentoRelacionado>();
            Mock<IFragmentoRelacionado> mockFragmentoRelacionado6 = new Mock<IFragmentoRelacionado>();
            Mock<IFragmentoRelacionado> mockFragmentoRelacionado7 = new Mock<IFragmentoRelacionado>();
            List<IFragmentoRelacionado> listaDeFragmentosRelacionados = new List<IFragmentoRelacionado>();

            Mock<IBitmapWrapper> mockImagenContenedora = new Mock<IBitmapWrapper>();
            Mock<IBitmapWrapper> mockImagen = new Mock<IBitmapWrapper>();

            listaDeFragmentosRelacionados.Add(mockFragmentoRelacionado0.Object);
            listaDeFragmentosRelacionados.Add(mockFragmentoRelacionado1.Object);
            listaDeFragmentosRelacionados.Add(mockFragmentoRelacionado2.Object);
            listaDeFragmentosRelacionados.Add(mockFragmentoRelacionado3.Object);
            listaDeFragmentosRelacionados.Add(mockFragmentoRelacionado4.Object);
            listaDeFragmentosRelacionados.Add(mockFragmentoRelacionado5.Object);
            listaDeFragmentosRelacionados.Add(mockFragmentoRelacionado6.Object);
            listaDeFragmentosRelacionados.Add(mockFragmentoRelacionado7.Object);

            mockFragmentoPrincipal.SetupGet(x => x.ReferenciasAFragmentosDeContexto).Returns(listaDeFragmentosRelacionados);
            mockFragmentoPrincipal.SetupGet(x => x.ImagenContenedoraWrapper).Returns(mockImagenContenedora.Object);
            mockFragmentoPrincipal.SetupGet(x => x.ImagenWrapper).Returns(mockImagen.Object);

            mockFragmentoRelacionado0.SetupGet(x => x.ImagenContenedoraWrapper).Returns(mockImagenContenedora.Object);
            mockFragmentoRelacionado0.SetupGet(x => x.ImagenWrapper).Returns(mockImagen.Object);
            mockFragmentoRelacionado0.SetupGet(x => x.NivelDeCercania).Returns(0);
            mockFragmentoRelacionado0.SetupGet(x => x.Zona).Returns(TipoDeZona.CuadranteInferiorDerecho);

            mockFragmentoRelacionado1.SetupGet(x => x.ImagenContenedoraWrapper).Returns(mockImagenContenedora.Object);
            mockFragmentoRelacionado1.SetupGet(x => x.ImagenWrapper).Returns(mockImagen.Object);
            mockFragmentoRelacionado1.SetupGet(x => x.NivelDeCercania).Returns(1);
            mockFragmentoRelacionado1.SetupGet(x => x.Zona).Returns(TipoDeZona.CuadranteInferiorIzquierdo);

            mockFragmentoRelacionado2.SetupGet(x => x.ImagenContenedoraWrapper).Returns(mockImagenContenedora.Object);
            mockFragmentoRelacionado2.SetupGet(x => x.ImagenWrapper).Returns(mockImagen.Object);
            mockFragmentoRelacionado2.SetupGet(x => x.NivelDeCercania).Returns(2);
            mockFragmentoRelacionado2.SetupGet(x => x.Zona).Returns(TipoDeZona.CuadranteSuperiorDerecho);

            mockFragmentoRelacionado3.SetupGet(x => x.ImagenContenedoraWrapper).Returns(mockImagenContenedora.Object);
            mockFragmentoRelacionado3.SetupGet(x => x.ImagenWrapper).Returns(mockImagen.Object);
            mockFragmentoRelacionado3.SetupGet(x => x.NivelDeCercania).Returns(3);
            mockFragmentoRelacionado3.SetupGet(x => x.Zona).Returns(TipoDeZona.CuadranteSuperiorIzquierdo);

            mockFragmentoRelacionado4.SetupGet(x => x.ImagenContenedoraWrapper).Returns(mockImagenContenedora.Object);
            mockFragmentoRelacionado4.SetupGet(x => x.ImagenWrapper).Returns(mockImagen.Object);
            mockFragmentoRelacionado4.SetupGet(x => x.NivelDeCercania).Returns(4);
            mockFragmentoRelacionado4.SetupGet(x => x.Zona).Returns(TipoDeZona.FranjaXNegativa);

            mockFragmentoRelacionado5.SetupGet(x => x.ImagenContenedoraWrapper).Returns(mockImagenContenedora.Object);
            mockFragmentoRelacionado5.SetupGet(x => x.ImagenWrapper).Returns(mockImagen.Object);
            mockFragmentoRelacionado5.SetupGet(x => x.NivelDeCercania).Returns(0);
            mockFragmentoRelacionado5.SetupGet(x => x.Zona).Returns(TipoDeZona.FranjaXPositiva);

            mockFragmentoRelacionado6.SetupGet(x => x.ImagenContenedoraWrapper).Returns(mockImagenContenedora.Object);
            mockFragmentoRelacionado6.SetupGet(x => x.ImagenWrapper).Returns(mockImagen.Object);
            mockFragmentoRelacionado6.SetupGet(x => x.NivelDeCercania).Returns(1);
            mockFragmentoRelacionado6.SetupGet(x => x.Zona).Returns(TipoDeZona.FranjaYNegativa);

            mockFragmentoRelacionado7.SetupGet(x => x.ImagenContenedoraWrapper).Returns(mockImagenContenedora.Object);
            mockFragmentoRelacionado7.SetupGet(x => x.ImagenWrapper).Returns(mockImagen.Object);
            mockFragmentoRelacionado7.SetupGet(x => x.NivelDeCercania).Returns(2);
            mockFragmentoRelacionado7.SetupGet(x => x.Zona).Returns(TipoDeZona.FranjaYPositiva);


            mockAnalizador.Setup(x => x.Configurar(It.IsAny<IFragmento>())).Callback<IFragmento>((fragmento) =>
            {
                ResultadoDeAnalisisDeFragmento resultado = new ResultadoDeAnalisisDeFragmento();
                resultado.Coincidencias = new List<TemplateMatch>() { new TemplateMatch(new Rectangle(), 0.99f) };
                resultado.Fragmento = fragmento;
                mockAnalizador.Setup(x => x.Ejecutar()).Returns(resultado);
            });

            var busqueda = new Mock<BusquedaBase<IAnalizador, ResultadoDeBusquedaExactaOriginal>>(mockAnalizador.Object) { CallBase = true }.Object;
            var resultadoEjecutar = busqueda.Ejecutar(mockFragmentoPrincipal.Object);

            Assert.IsNotNull(resultadoEjecutar);
            Assert.IsTrue(resultadoEjecutar.PositivoFragmentoPrincipal);
            Assert.IsTrue(resultadoEjecutar.PositivosPorNivelDeCercania.All(x => x.Value));
            Assert.IsTrue(resultadoEjecutar.PositivosPorZona.All(x => x.Value));
        }
    }
}
