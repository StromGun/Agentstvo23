using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agentstvo23
{
    class Program
    {
        [STAThread] static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            //.ConfigureAppConfiguration((host, cfg) => cfg
            //.SetBasePath(Environment.CurrentDirectory)
            //.AddJsonFile("appsettings.json",optional: true, reloadOnChange: true))
            .ConfigureServices(App.ConfigureServices);

    }
}
