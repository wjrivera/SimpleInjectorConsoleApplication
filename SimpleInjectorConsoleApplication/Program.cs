using System;
using System.IO;
using SimpleInjectorLibrary;
using Microsoft.Extensions.Configuration;
using SimpleInjectorConsoleApplication.Tools;
using SimpleInjectorLibrary.Models;
using SimpleInjectorLibrary.Services;

namespace SimpleInjectorConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //load values from appsettings.json
            Console.WriteLine(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var config = builder.Build();


            //simple injector custom library
            var simpleInjector = new SimpleInjectorLibraryClass();
            simpleInjector.SetupContainerRegistration();
            simpleInjector.VerifyTheContainer();
            var container = simpleInjector.Container;

            //Get service to use
            var nameService = container.GetInstance<NameService>();
            
            //Set name and id
            nameService.SetName(config.GetSection("Configuration").GetSection("Name").Value);
            nameService.SetId(config.GetSection("Configuration").GetSection("Id").Value);
            Console.WriteLine(nameService.GetUser("1234").Name);

            var tool = new NameServiceTool(nameService);
            tool.RunThisTool();

        }
    }
}
