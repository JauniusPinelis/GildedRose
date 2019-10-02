using GildedRose.Business;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace GildedRose.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IApplication, GildedRoseApp>()
            .BuildServiceProvider();

            var app = serviceProvider.GetService<IApplication>();
            app.Run();
            
        }
    }
}
