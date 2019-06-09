using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Autofac.Integration.Wcf;

namespace Server.Framework
{
    class Host<T> : ServiceHost
    {
        public Host() : base(typeof(T))
        {
            this.AddDependencyInjectionBehavior(typeof(T), Program.Container);
        }
       
    }
}
