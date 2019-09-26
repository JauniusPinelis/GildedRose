using Autofac;
using GildedRose.Business;
using System;
using System.Collections.Generic;

namespace GildedRose.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}
