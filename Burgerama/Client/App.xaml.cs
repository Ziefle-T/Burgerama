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
using Client.Server.Models;
using Client.Server.Services;
using Client.ViewModels;

namespace Client
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }

        public static User LoggedInUser { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            SetupDIContainer();

            using (var lifetime = Container.BeginLifetimeScope())
            {
                LoginController loginController = lifetime.Resolve<LoginController>();
                var loginResult = loginController.Login();
                if (loginResult.success)
                {
                    LoggedInUser = loginResult.user;

                    var mainWindowController = lifetime.Resolve<MainWindowController>();
                    mainWindowController.Initialize(loginResult.user.IsAdmin);
                }
            }

            this.Shutdown();
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

            containerBuilder.Register(c => new ChannelFactory<ICustomerService>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:8733/Design_Time_Addresses/Server.Services/CustomerService/")
            )).SingleInstance();
            containerBuilder.Register(c => c.Resolve<ChannelFactory<ICustomerService>>().CreateChannel())
                .As<ICustomerService>()
                .UseWcfSafeRelease();

            containerBuilder.Register(c => new ChannelFactory<IOrderService>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:8733/Design_Time_Addresses/Server.Services/OrderService/")
            )).SingleInstance();
            containerBuilder.Register(c => c.Resolve<ChannelFactory<IOrderService>>().CreateChannel())
                .As<IOrderService>()
                .UseWcfSafeRelease();

            containerBuilder.Register(c => new ChannelFactory<IOrderLinesService>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:8733/Design_Time_Addresses/Server.Services/OrderLinesService/")
            )).SingleInstance();
            containerBuilder.Register(c => c.Resolve<ChannelFactory<IOrderLinesService>>().CreateChannel())
                .As<IOrderLinesService>()
                .UseWcfSafeRelease();

            containerBuilder.Register(c => new ChannelFactory<IArticleService>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:8733/Design_Time_Addresses/Server.Services/ArticleService/")
            )).SingleInstance();
            containerBuilder.Register(c => c.Resolve<ChannelFactory<IArticleService>>().CreateChannel())
                .As<IArticleService>()
                .UseWcfSafeRelease();

            containerBuilder.Register(c => new ChannelFactory<IDriverService>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:8733/Design_Time_Addresses/Server.Services/DriverService/")
            )).SingleInstance();
            containerBuilder.Register(c => c.Resolve<ChannelFactory<IDriverService>>().CreateChannel())
                .As<IDriverService>()
                .UseWcfSafeRelease();

            containerBuilder.Register(c => new ChannelFactory<IAreaService>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:8733/Design_Time_Addresses/Server.Services/AreaService/")
            )).SingleInstance();
            containerBuilder.Register(c => c.Resolve<ChannelFactory<IAreaService>>().CreateChannel())
                .As<IAreaService>()
                .UseWcfSafeRelease();
            
            //Register Controllers
            containerBuilder.RegisterType<LoginController>();
            containerBuilder.RegisterType<MainWindowController>();
            containerBuilder.RegisterType<StartViewController>();
            containerBuilder.RegisterType<ChangePasswordController>();
            containerBuilder.RegisterType<CustomerViewController>();
            containerBuilder.RegisterType<OrderViewController>();
            containerBuilder.RegisterType<BestsellerViewController>();
            containerBuilder.RegisterType<RevenueListViewController>();
            containerBuilder.RegisterType<ArticleViewController>();
            containerBuilder.RegisterType<DriverViewController>();
            containerBuilder.RegisterType<AreaViewController>();
            containerBuilder.RegisterType<UserViewController>();
            containerBuilder.RegisterType<AddArticleViewController>();

            //Register View-Models
            containerBuilder.RegisterType<StartViewModel>();
            containerBuilder.RegisterType<CustomerViewModel>();
            containerBuilder.RegisterType<OrderViewModel>();
            containerBuilder.RegisterType<BestsellerViewModel>();
            containerBuilder.RegisterType<RevenueListViewModel>();
            containerBuilder.RegisterType<ArticleViewModel>();
            containerBuilder.RegisterType<DriverViewModel>();
            containerBuilder.RegisterType<AreaViewModel>();
            containerBuilder.RegisterType<UserViewModel>();

            Container = containerBuilder.Build();
        }
    }
}
