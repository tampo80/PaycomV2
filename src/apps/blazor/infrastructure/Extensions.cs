﻿using System.Globalization;
using Blazored.LocalStorage;
using PayCom.Blazor.Infrastructure.Api;
using PayCom.Blazor.Infrastructure.Auth;
using PayCom.Blazor.Infrastructure.Auth.Jwt;
using PayCom.Blazor.Infrastructure.Notifications;
using PayCom.Blazor.Infrastructure.Preferences;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;


namespace PayCom.Blazor.Infrastructure;
public static class Extensions
{
    private const string ClientName = "Innovative.API";
    public static IServiceCollection AddClientServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddMudServices(configuration =>
        {
            configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
            configuration.SnackbarConfiguration.HideTransitionDuration = 100;
            configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
            configuration.SnackbarConfiguration.VisibleStateDuration = 3000;
            configuration.SnackbarConfiguration.ShowCloseIcon = false;
        });
        services.AddBlazoredLocalStorage();
        services.AddAuthentication(config);
        services.AddTransient<IApiClient, ApiClient>();
        services.AddHttpClient(ClientName, client =>
        {
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName);
            client.BaseAddress = new Uri(config["ApiBaseUrl"]!);
        })
           .AddHttpMessageHandler<JwtAuthenticationHeaderHandler>()
           .Services
           .AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(ClientName));
        services.AddTransient<IClientPreferenceManager, ClientPreferenceManager>();
        services.AddTransient<IPreference, ClientPreference>();
        services.AddNotifications();
        
      
        
        return services;
    }
}
