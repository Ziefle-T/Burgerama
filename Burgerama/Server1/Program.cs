using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Wcf;
using Server.Framework;
using Server.Models;
using Server.Services;

namespace Server
{
    class Program
    {
        public static IContainer Container { get; private set; }

        static void Main(string[] args)
        {
            SetupDIContainer();

            ServiceHost areaServiceHost = Container.Resolve<Host<AreaService>>();
            ServiceHost articleServiceHost = Container.Resolve<Host<ArticleService>>();
            ServiceHost customerServiceHost = Container.Resolve<Host<CustomerService>>();
            ServiceHost driverServiceHost = Container.Resolve<Host<DriverService>>();
            ServiceHost orderLinesServiceHost = Container.Resolve<Host<OrderLinesService>>();
            ServiceHost orderServiceHost = Container.Resolve<Host<OrderService>>();
            ServiceHost userServiceHost = Container.Resolve<Host<UserService>>();

            areaServiceHost.Open();
            articleServiceHost.Open();
            customerServiceHost.Open();
            driverServiceHost.Open();
            orderLinesServiceHost.Open();
            orderServiceHost.Open();
            userServiceHost.Open();
            
            Console.WriteLine("hosted successfull");
            Console.ReadLine();

            areaServiceHost.Close();
            articleServiceHost.Close();
            customerServiceHost.Close();
            driverServiceHost.Close();
            orderLinesServiceHost.Close();
            orderServiceHost.Close();
            userServiceHost.Close();
        }

        private static void SetupDIContainer()
        {
            var containerBuilder = new ContainerBuilder();
            //Register Repositories
            containerBuilder.RegisterType<NHibernateHelper>().As<INHibernateHelper>().SingleInstance();
            containerBuilder.RegisterType<Repository<Area>>().As<IRepository<Area>>();
            containerBuilder.RegisterType<Repository<Article>>().As<IRepository<Article>>();
            containerBuilder.RegisterType<Repository<Customer>>().As<IRepository<Customer>>();
            containerBuilder.RegisterType<Repository<Driver>>().As<IRepository<Driver>>();
            containerBuilder.RegisterType<Repository<Order>>().As<IRepository<Order>>();
            containerBuilder.RegisterType<Repository<OrderLines>>().As<IRepository<OrderLines>>();
            containerBuilder.RegisterType<Repository<User>>().As<IRepository<User>>();

            //Register Services
            containerBuilder.RegisterType<AreaService>();
            containerBuilder.RegisterType<ArticleService>();
            containerBuilder.RegisterType<CustomerService>();
            containerBuilder.RegisterType<DriverService>();
            containerBuilder.RegisterType<OrderLinesService>();
            containerBuilder.RegisterType<OrderService>();
            containerBuilder.RegisterType<UserService>();

            //Regisert Service-Hosts
            containerBuilder.RegisterType<Host<AreaService>>();
            containerBuilder.RegisterType<Host<ArticleService>>();
            containerBuilder.RegisterType<Host<CustomerService>>();
            containerBuilder.RegisterType<Host<DriverService>>();
            containerBuilder.RegisterType<Host<OrderLinesService>>();
            containerBuilder.RegisterType<Host<OrderService>>();
            containerBuilder.RegisterType<Host<UserService>>();

            Container = containerBuilder.Build();
            AutofacHostFactory.Container = Container;
        }
    }
}
