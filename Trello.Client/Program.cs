using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Trello.Client;
using Trello.Client.Events;
using Trello.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("API", client => client.BaseAddress = new Uri("https://localhost:7239"));

builder.Services
.AddBlazorise(options =>
{
    options.Immediate = true;
})
.AddBootstrap5Providers()
.AddFontAwesomeIcons();

builder.Services.AddSingleton<EventAggregator>();

builder.Services.AddSingleton<CurrentUser>();

builder.Services.AddSingleton<Utils>();

await builder.Build().RunAsync();
