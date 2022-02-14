using Autofac;
using Castle.DynamicProxy;
using DemoLibrary;
using DemoLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using System.IO;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().Where(i => i.Name == "I" + t.Name))
                .EnableInterfaceInterceptors();
            builder.RegisterType<StartUp>().As<IStartUp>();
            builder.Register(c => new LogInterceptor(Console.Out))
                .Named<IInterceptor>("Log_calls");
            builder.RegisterType<LogInterceptor>().As<IInterceptor>();

            return builder.Build();
        }
    }
}
