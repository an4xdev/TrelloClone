using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(http => new HttpClient()
{
    BaseAddress = new Uri("https://localhost:7239")
});

builder.Services
.AddBlazorise(options =>
{
    options.Immediate = true;
})
.AddBootstrap5Providers()
.AddFontAwesomeIcons();

await builder.Build().RunAsync();
