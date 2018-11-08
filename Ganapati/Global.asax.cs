using Autofac;
using Autofac.Integration.WebApi;
using Ganapati.Repo;
using Ganapati.Services;
using System.Reflection;
using System.Web.Http;

namespace Ganapati
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            var config = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<GameService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<PlayerService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<PlayerRepo>().AsImplementedInterfaces().InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            

        }
    }
}
