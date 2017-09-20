namespace img.Configuracion
{
    using Algoritmos;
    using Algoritmos.Comun;
    using Analizadores;
    using Analizadores.Atributos;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Comun;
    using ProcesamientoDeImagen;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DIContainer : IDisposable
    {
        public DIContainer()
        {
            this.Configurar();
        }

        public IWindsorContainer Contenedor { get; private set; }

        private void Configurar()
        {
            this.Contenedor = new WindsorContainer();

            // adds and configures all components using WindsorInstallers from executing assembly
            //this.Contenedor.Install(FromAssembly.This());
            this.Contenedor.Register(Component.For<IProcesador>().ImplementedBy<Procesador>().LifestyleTransient());

            this.Contenedor.Register(Component.For<IFragmentoRelacionado>().ImplementedBy<FragmentoRelacionado>().LifestyleTransient());
            this.Contenedor.Register(Component.For<IFragmentoPrincipal>().ImplementedBy<FragmentoPrincipal>().LifestyleTransient());

            this.Contenedor.Register(Component.For<FragmentadorDeImagenCompleta>().LifestyleTransient());

            this.Contenedor.Register(Component.For<BusquedaExactaEnImagenCompleta>().LifestyleTransient());
            this.Contenedor.Register(Component.For<BusquedaExactaOriginal>().LifestyleTransient());
            this.Contenedor.Register(Component.For<BusquedaExactaPorContenedorExtendido>().LifestyleTransient());
            this.Contenedor.Register(Component.For<BusquedaExactaSoloParametrosRelacionados>().LifestyleTransient());
            this.Contenedor.Register(Component.For<BusquedaNoExactaEnImagenCompleta>().LifestyleTransient());
            this.Contenedor.Register(Component.For<BusquedaNoExactaOriginal>().LifestyleTransient());
            this.Contenedor.Register(Component.For<BusquedaNoExactaPorContenedorExtendido>().LifestyleTransient());
            this.Contenedor.Register(Component.For<BusquedaNoExactaSoloParametrosRelacionados>().LifestyleTransient());

            this.Contenedor.Register(Component.For<AtributoCoeficienteDeSimilitudExacto>().LifestyleTransient());
            this.Contenedor.Register(Component.For<AtributoCoeficienteDeSimilitudNoExacto>().LifestyleTransient());
            this.Contenedor.Register(Component.For<AtributoContenedorDeBusquedaTamañoX>().LifestyleTransient());
            this.Contenedor.Register(Component.For<AtributoContenedorMaximoDeBusqueda>().LifestyleTransient());
            this.Contenedor.Register(Component.For<AtributoUbicacionCentralRespectoAOriginal>().LifestyleTransient());

            this.Contenedor.Register(Component.For<AnalizadorPorBusquedaExactaEnContenedorExtendido>().LifestyleTransient());
            this.Contenedor.Register(Component.For<AnalizadorPorBusquedaExactaEnImagenCompleta>().LifestyleTransient());
            this.Contenedor.Register(Component.For<AnalizadorPorBusquedaExactaOriginal>().LifestyleTransient());
            this.Contenedor.Register(Component.For<AnalizadorPorBusquedaNoExactaEnContenedorExtendido>().LifestyleTransient());
            this.Contenedor.Register(Component.For<AnalizadorPorBusquedaNoExactaEnImagenCompleta>().LifestyleTransient());
            this.Contenedor.Register(Component.For<AnalizadorPorBusquedaNoExactaOriginal>().LifestyleTransient());

            this.Contenedor.Register(Component.For<IBitmapWrapper>().ImplementedBy<BitmapWrapper>().LifestyleTransient()); 

            this.Contenedor.Register(Component.For<IAnalizadorPorBusquedaExactaEnContenedorExtendido>().ImplementedBy<AnalizadorPorBusquedaExactaEnContenedorExtendido>().LifestyleTransient());
            this.Contenedor.Register(Component.For<IAnalizadorPorBusquedaExactaEnImagenCompleta>().ImplementedBy<AnalizadorPorBusquedaExactaEnImagenCompleta>().LifestyleTransient());
            this.Contenedor.Register(Component.For<IAnalizadorPorBusquedaExactaOriginal>().ImplementedBy<AnalizadorPorBusquedaExactaOriginal>().LifestyleTransient());
            this.Contenedor.Register(Component.For<IAnalizadorPorBusquedaNoExactaEnContenedorExtendido>().ImplementedBy<AnalizadorPorBusquedaNoExactaEnContenedorExtendido>().LifestyleTransient());
            this.Contenedor.Register(Component.For<IAnalizadorPorBusquedaNoExactaEnImagenCompleta>().ImplementedBy<AnalizadorPorBusquedaNoExactaEnImagenCompleta>().LifestyleTransient());
            this.Contenedor.Register(Component.For<IAnalizadorPorBusquedaNoExactaOriginal>().ImplementedBy<AnalizadorPorBusquedaNoExactaOriginal>().LifestyleTransient());

            this.Contenedor.Register(Component.For<IDivisorDeImagenCompleta>().ImplementedBy<FragmentadorDeImagenCompleta>().LifestyleTransient());
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Contenedor.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}

