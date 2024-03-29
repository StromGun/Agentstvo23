﻿using Microsoft.Extensions.DependencyInjection;

namespace Agentstvo23.ViewModels
{
    static class ViewModelsRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddScoped<MainWindowViewModel>()
            .AddScoped<AuthorizationViewModel>()
            .AddTransient<NavigationViewModel>()
            .AddTransient<RealEstatesViewModel>()
            .AddTransient<ApartmentsViewModel>()
            ;
    }
}
