using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Multitenant;
using MultiTenant.App.Sample.UI.Layer.Controllers;
using MultiTenant.App.Sample.UI.Layer.Infrastructure;
using MultiTenant.App.Sample.UI.Layer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MultiTenant.App.Sample.UI.Layer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DefaultUserService>().As<IUserService>();

            // If you have tenant-specific controllers in the same assembly as the
            // application, you should register controllers individually.
            builder.RegisterType<HomeController>();
            builder.RegisterType<Tenant1Controller>();
            builder.RegisterType<Tenant2Controller>();

            // Set up the tenant ID strategy and application container.
            // The request parameter tenant ID strategy is used here as an example.
            builder.RegisterType<TenantIdentificationStrategy>().As<ITenantIdentificationStrategy>();

            var appContainer = builder.Build();

            // Create the multitenant container and the tenant overrides.
            var mtc = new MultitenantContainer(appContainer.Resolve<ITenantIdentificationStrategy>(), appContainer);

            mtc.ConfigureTenant("Tenant1",
              b =>
              {
                  b.RegisterType<Tenant1Controller>().As<HomeController>();
                  b.RegisterType<Tenant1UserService>().As<IUserService>().InstancePerDependency();
              });

            mtc.ConfigureTenant("Tenant2",
              b =>
              {
                  b.RegisterType<Tenant2Controller>().As<HomeController>();
                  b.RegisterType<Tenant2UserService>().As<IUserService>().InstancePerDependency();
              });

            // Set up the DependencyResolver using a multitenant container rather than a regular container.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(mtc));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
