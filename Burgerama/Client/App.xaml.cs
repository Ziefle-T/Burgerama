using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Client.Controllers;
using Client.Server.Services;

namespace Client
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            SetupDIContainer();

            LoginController loginController = Container.Resolve<LoginController>();
            if (loginController.Login())
            {

            }
        }

        private void SetupDIContainer()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            //Register WCF-Service-Clients
            containerBuilder.RegisterType<AreaServiceClient>().As<IAreaService>();
            containerBuilder.RegisterType<ArticleServiceClient>().As<IArticleService>();
            containerBuilder.RegisterType<CustomerServiceClient>().As<ICustomerService>();
            containerBuilder.RegisterType<DriverServiceClient>().As<IDriverService>();
            containerBuilder.RegisterType<OrderLinesServiceClient>().As<IOrderLinesService>();
            containerBuilder.RegisterType<OrderServiceClient>().As<IOrderService>();
            containerBuilder.RegisterType<UserServiceClient>().As<IUserService>();

            //Register Controllers
            containerBuilder.RegisterType<LoginController>();

            Container = containerBuilder.Build();
        }
    }
}
