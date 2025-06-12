using PayCom.Blazor.Client;
using PayCom.Blazor.Client.Extensions;
using PayCom.Blazor.Infrastructure;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Ajouter les services de l'infrastructure
builder.Services.AddClientServices(builder.Configuration);

// Ajouter les services spécifiques au client
builder.Services.AddClientServices();

// Ajouter les services MudBlazor
builder.Services.AddMudServices();

// Services de l'application - TypeTaxeService supprimé, utilisation directe de l'ApiClient

await builder.Build().RunAsync();
