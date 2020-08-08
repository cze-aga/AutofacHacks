using Autofac;
using AutofacHackService;
using AutofacHackService.Interfaces;
using System.Linq;
using System.Reflection;

namespace AutofacHacks
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //whenever you ask about new StartApplication I will give you new instance
            builder.RegisterType<StartApplication>().As<IStartApplication>();

            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();
            //builder.RegisterType<SleeperImpl>().As<ISleeper>();
            //builder.RegisterType<WorkerImpl>().As<IWorker>();
            ////the simplest way of registering class as imlementation of interface
            ////"register a component to be created through reflection"
            //builder.RegisterType<Worker>().As<IWorker>();

            //strongly typed name in nameof - benefit - so DO NOT PUT STRING THERE 
            // - it can be any object in given assembly
            //what we are doing here - register all classes in AutofacHackService
            //and link them up to the matching Interfaces
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(AutofacHackService)))
                .Where(t => t.Namespace.Contains("Interfaces"))
                .Where(t => t.Name.Contains("Impl"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name.Replace("Impl","")));



            return builder.Build();
        }
    }
}
