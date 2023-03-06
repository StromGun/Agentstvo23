using Microsoft.Extensions.DependencyInjection;

namespace Agentstvo23.ViewModels
{
    static class ViewModelsRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddTransient<NavigationViewModel>()
            .AddTransient<RealEstatesViewModel>()
            ;
    }
}
