using Microsoft.Extensions.DependencyInjection;
using Parser.WPF.MVVM.ViewModel;

namespace Parser.WPF.HostBuilder
{
    public static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModel(this IServiceCollection services) => services
            .AddTransient<MainWindowViewModel>();
    }
}
