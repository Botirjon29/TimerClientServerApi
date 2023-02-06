using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TimerMudBlazor;
using MudBlazor.Services;
using TimerMudBlazor.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<TimerService>();

builder.Services.AddScoped(sp => new HttpClient());
builder.Services.AddMudServices();

await builder.Build().RunAsync();