using System;
using System.Threading.Tasks;
using CodingTest.DepthCharts.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodingTest.DepthCharts
{
    public static class Program
    {
        public static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            host.Services.GetService<DepthChartApplication>()?.Run();
            
            return host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services
                        .AddTransient<IConsoleService, Services.ConsoleService>()
                        .AddSingleton<DepthChartApplication>());
        }
    }
}