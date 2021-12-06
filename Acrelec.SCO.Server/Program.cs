using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Internal;
using System;

namespace Acrelec.SCO.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the SCO Server");
            var builder = BuildWebHost(args);
            builder.Run();
            //todo - implement REST server accepting the 2 API methods
        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
    }
}
