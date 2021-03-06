using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
                //// NLog: setup the logger first to catch all errors
                //var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
                //try
                //{
                //    logger.Debug("init main");
                //    CreateWebHostBuilder(args).Build().Run();
                //}
                //catch (Exception ex)
                //{
                //    //NLog: catch setup errors
                //    logger.Error(ex, "Stopped program because of exception");
                //    throw;
                //}
                //finally
                //{
                //    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                //    NLog.LogManager.Shutdown();
                //}
                CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
