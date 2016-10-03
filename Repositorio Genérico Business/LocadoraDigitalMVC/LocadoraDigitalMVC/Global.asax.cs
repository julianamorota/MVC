using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LocadoraDigitalMVC.Repository.EntityFramework.Context;
using System.Reflection;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using LocadoraDigitalMVC.IRepository;
using LocadoraDigitalMVC.Repository.EntityFramework;
using LocadoraDigitalMVC.IBusiness;
using LocadoraDigitalMVC.Business;
using LocadoraDigitalMVC.IRepository.RepositorioGenerico;
using LocadoraDigitalMVC.Repository.EntityFramework.RepositorioGenerico;
using SimpleInjector.Extensions;
using LocadoraDigitalMVC.Entities;

namespace LocadoraDigitalMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
      
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            #region database configuration
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LocadoraDigitalMVCContext>());
            #endregion

            #region simple injector

            //Code for registering our repository class and DI
            var container = new Container();
            container.Register<IClientRepository, ClienteRepository>();
            container.Register<IClienteBusiness, ClienteBusiness>();
            container.Register<IDevolucaoRepository, DevolucaoRepository>();
            container.Register<IDevolucaoBusiness, DevolucaoBusiness>();
            container.Register<IFilmeRepository, FilmeRepository>();
            container.Register<IFilmeBusiness, FilmeBusiness>();
            container.Register<IGeneroRepository, GeneroRepository>();
            container.Register<IGeneroBusiness, GeneroBusiness>();
            container.Register<ILocacaoRepository, LocacaoRepository>();
            container.Register<ILocacaoBusiness, LocacaoBusiness>();
            container.Register<IRepositorioGenerico<Cliente>, RepositorioGenerico<Cliente>>();
            container.Register<IRepositorioGenerico<Genero>, RepositorioGenerico<Genero>>();
            //container.Register(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
            
            // This two extension method from integration package
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));

            #endregion

        }


    }
}
