using Blazored.LocalStorage;
using DRApplication.Client;
using DRApplication.Client.Interfaces;
using DRApplication.Client.Services;
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

builder.Services.AddScoped<AppState>();
builder.Services.AddScoped<CurrentLoadManager>();
builder.Services.AddScoped<DeviceManager>();
builder.Services.AddScoped<DeviceTypeManager>();
builder.Services.AddScoped<HardwareConfigManager>();
builder.Services.AddScoped<HardwareSystemManager>();
builder.Services.AddScoped<HardwareVersionManager>();
builder.Services.AddScoped<HardwareVersionsConfigManager>();
builder.Services.AddScoped<LoadManager>();
builder.Services.AddScoped<MaintainerManager>();
builder.Services.AddScoped<SpecificLoadManager>();
builder.Services.AddScoped<SoftwareSystemManager>();
builder.Services.AddScoped<SoftwareVersionManager>();
builder.Services.AddScoped<VersionsLoadManager>();

builder.Services.AddTransient<IPlatformService, PlatformService>();
builder.Services.AddTransient<ILoadService, LoadService>();
builder.Services.AddTransient<IHardwareService, HardwareService>();
builder.Services.AddTransient<ISoftwareService, SoftwareService>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
