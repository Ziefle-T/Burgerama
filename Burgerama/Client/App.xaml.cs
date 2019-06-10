using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Autofac.Integration.Wcf;
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

            using (var lifetime = Container.BeginLifetimeScope())
            {
                LoginController loginController = lifetime.Resolve<LoginController>();
                var loginResult = loginController.Login();
                if (loginResult.success)
                {
                    Console.WriteLine("logged in");
                }
            }
        }

        private void SetupDIContainer()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            //Register WCF-Service-Clients
            containerBuilder.Register(c => new ChannelFactory<IUserService>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:8733/Design_Time_Addresses/Server.Services/UserService/")
                )).SingleInstance();
            containerBuilder.Register(c => c.Resolve<ChannelFactory<IUserService>>().CreateChannel())
                .As<IUserService>()
                .UseWcfSafeRelease();

            //containerBuilder.RegisterType<ArticleServiceClient>().As<IArticleService>();
            //containerBuilder.RegisterType<CustomerServiceClient>().As<ICustomerService>();
            //containerBuilder.RegisterType<DriverServiceClient>().As<IDriverService>();
            //containerBuilder.RegisterType<OrderLinesServiceClient>().As<IOrderLinesService>();
            //containerBuilder.RegisterType<OrderServiceClient>().As<IOrderService>();
            //containerBuilder.RegisterType<UserServiceClient>().As<IUserService>();

            //Register Controllers
            containerBuilder.RegisterType<LoginController>();

            Container = containerBuilder.Build();
        }
    }
}
