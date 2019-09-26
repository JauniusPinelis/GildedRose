using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.ConsoleApp
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            return builder.Build();
        }
    }
}
