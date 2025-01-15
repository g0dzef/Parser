using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Parser.WPF.HostBuilder;
using Parser.WPF.Windows;
using System.IO;
using System.Windows;

namespace Parser.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

        private static IHost? _host;
        public static IHost Host => _host ?? Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();


        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Window window = Host.Services.GetRequiredService<MainWindow>();
            window.Show();

            await Host.RunAsync().ConfigureAwait(false);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            Host?.Dispose();

            Host?.StopAsync().ConfigureAwait(false);
        }

        public static void ConfigureServices(IServiceCollection services) => services
            .AddWindows()
            .AddViewModel();

        public static void BuildConfig(IConfigurationBuilder builder) => builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
    }

}
