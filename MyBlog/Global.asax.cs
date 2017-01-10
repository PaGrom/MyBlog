using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common;
using MyBlog.Core;

namespace MyBlog
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(new RepositoryModule());
            kernel.Bind<IBlogRepository>().To<BlogRepository>();

            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            base.OnApplicationStarted();
        }
    }
}
