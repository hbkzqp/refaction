using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ProductServices.Implementation;
using ProductServices.Interface;
using refactor_me.Helpers;
using Autofac.Integration.WebApi;

namespace refactor_me.App_Start
{
    public class DIConfig
    {
        private static volatile DIConfig instance = null;
        public static DIConfig getInstance()
        {
            if (instance == null)
            {
                instance = new DIConfig();
            }

            return instance;
        }
        private DIConfig() { }

        public void ConfigServices()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            List<NamedParameter> ListNamedParameter = new List<NamedParameter>() { new NamedParameter("ConnectionStringOrName", Constant.CONNECTION_STRING) };
            builder.RegisterType<ProductService>().WithParameters(ListNamedParameter).As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductOptionService>().WithParameters(ListNamedParameter).As<IProductOptionService>().InstancePerLifetimeScope();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //var builder = new ContainerBuilder();
            //builder.RegisterControllers(typeof(ApiController).Assembly);
            //List<NamedParameter> ListNamedParameter = new List<NamedParameter>() { new NamedParameter("ConnectionStringOrName", Constant.CONNECTION_STRING) };
            //builder.RegisterType<ProductService>().WithParameters(ListNamedParameter).As<IProductService>().InstancePerLifetimeScope();
            //builder.RegisterType<ProductOptionService>().WithParameters(ListNamedParameter).As<IProductOptionService>().InstancePerLifetimeScope();
            //IContainer container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}