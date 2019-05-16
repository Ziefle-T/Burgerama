using Server1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost userServiceHost = new ServiceHost(typeof(UserService));
            ServiceHost driverServiceHost = new ServiceHost(typeof(DriverService));

            userServiceHost.Open();
            driverServiceHost.Open();

            Console.WriteLine("hosted successfull");
            Console.ReadLine();

            userServiceHost.Close();
            driverServiceHost.Close();
        }
    }
}
