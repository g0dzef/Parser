using Microsoft.Extensions.DependencyInjection;
using Parser.WPF.Services.HTML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.WPF.HostBuilder
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddHttpClient()
            .AddSingleton<Loader>();
    }
}
