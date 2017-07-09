[assembly: WebActivator.PostApplicationStartMethod(typeof(WebApp.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace WebApp.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using WebApp.Servicios;
    using WebApp.Data.Contratos;
    using WebApp.Models;
    using WebApp.Data.Repositorios;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            container.Register<IRepositorio<Persona>, Repositorio<Persona>>(Lifestyle.Scoped);
            container.Register<IRepositorioDePersonas, RepositorioDePersonas>(Lifestyle.Scoped);

        }
    }
}