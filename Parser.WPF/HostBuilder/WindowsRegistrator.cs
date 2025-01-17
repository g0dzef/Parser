using Microsoft.Extensions.DependencyInjection;
using Parser.WPF.MVVM.ViewModel;
using Parser.WPF.Windows;

namespace Parser.WPF.HostBuilder
{
    public static class WindowsRegistrator
    {
        public static IServiceCollection AddWindows(this IServiceCollection services) => services
            .AddSingleton(s =>  new MainWindow(s.GetRequiredService<MainWindowViewModel>()));
    }
}
