using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace AdvantureWork.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return
            Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(GetWebHostBuilder());
        }

        private static Action<IWebHostBuilder> GetWebHostBuilder()
        {
            var config = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: false)
                  .Build();

            return webBuilder =>
            {
                webBuilder.UseStartup<Startup>().UseConfiguration(config);
                // .UseKestrel();
            };
        }
    }
}