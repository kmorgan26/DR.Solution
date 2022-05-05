using Blazored.LocalStorage;
using DRApplication.Client;
using DRApplication.Client.Services.Configurations;
using DRApplication.Client.Services.Platforms.Devices;
using DRApplication.Client.Services.Platforms.DeviceTypes;
using DRApplication.Client.Services.Platforms.Maintainers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();

builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<HardwareConfigManager>();
builder.Services.AddScoped<HardwareSystemManager>();
builder.Services.AddScoped<DeviceTypeManager>();
builder.Services.AddScoped<DeviceManager>();
builder.Services.AddScoped<MaintainerManager>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
