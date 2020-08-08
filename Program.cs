using Autofac;
using AutofacHackService;
using System;

namespace AutofacHacks
{
    class Program
    {
        static void Main(string[] args)
        {
           var container = ContainerConfig.Configure();

            //creating new scope for instances being passed out
            using(var scope = container.BeginLifetimeScope())
            {
                //what I say- I need an IStartApplication object
                var app = scope.Resolve<IStartApplication>();
                app.Run();
            }

            Console.ReadLine();  
        }
    }
}
