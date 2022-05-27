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

builder.Services.AddScoped<HardwareConfigManager>();
builder.Services.AddScoped<HardwareSystemManager>();
builder.Services.AddScoped<HardwareVersionManager>();
builder.Services.AddScoped<HardwareVersionsConfigManager>();

builder.Services.AddScoped<SoftwareSystemManager>();
builder.Services.AddScoped<SoftwareVersionManager>();

builder.Services.AddScoped<LoadManager>();
builder.Services.AddScoped<VersionsLoadManager>();

builder.Services.AddScoped<MaintainerManager>();
builder.Services.AddScoped<DeviceTypeManager>();
builder.Services.AddScoped<DeviceManager>();

builder.Services.AddTransient<IPlatformService, PlatformService>();
builder.Services.AddTransient<ILoadBuilderService, LoadBuilderService>();
builder.Services.AddTransient<IGenericListService, GenericListService>();

builder.Services.AddTransient(typeof(ITableService<>), typeof(TableService<>));

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
