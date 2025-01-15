using Microsoft.Extensions.Hosting;

namespace Parser.WPF
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            App.BuildConfig(App.configurationBuilder);

            var app = new App();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(App.ConfigureServices);
    }
}
