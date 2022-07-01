using Blazored.LocalStorage;
using DRApplication.Client;
using DRApplication.Client.Helpers;
using DRApplication.Client.Interfaces;
using DRApplication.Client.Services;
using DRApplication.Client.Validators;
using DRApplication.Client.ViewModels;
using FluentValidation;
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
builder.Services.AddScoped<CorrectiveActionManager>();
builder.Services.AddScoped<CurrentLoadManager>();
builder.Services.AddScoped<DeviceDiscoveredManager>();
builder.Services.AddScoped<DeviceManager>();
builder.Services.AddScoped<DeviceTypeManager>();
builder.Services.AddScoped<DrManager>();
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
builder.Services.AddScoped<IssueManager>();
builder.Services.AddScoped<MaintIssueManager>();
builder.Services.AddScoped<PlatformHelpers>();

builder.Services.AddScoped<ManagerService>();

builder.Services.AddTransient<IPlatformService, PlatformService>();
builder.Services.AddTransient<ILoadService, LoadService>();
builder.Services.AddTransient<IHardwareService, HardwareService>();
builder.Services.AddTransient<ISoftwareService, SoftwareService>();
builder.Services.AddTransient<IIssueService, IssueService>();
builder.Services.AddTransient<IMapperService, MapperService>();
builder.Services.AddTransient<ILoadHelpers, LoadHelpers>();

builder.Services.AddTransient<IValidator<MaintainerEditVm>, MaintainerEditVmValidator>();
builder.Services.AddTransient<IValidator<DeviceTypeEditVm>, DeviceTypeEditVmValidator>();
builder.Services.AddTransient<IValidator<DeviceTypeVm>, DeviceTypeVmValidator>();
builder.Services.AddTransient<IValidator<DeviceEditVm>, DeviceEditVmValidator>();
builder.Services.AddTransient<IValidator<DeviceInsertVm>, DeviceInsertVmValidator>();
builder.Services.AddTransient<IValidator<HardwareSystemEditVm>, HardwareSystemEditVmValidator>();
builder.Services.AddTransient<IValidator<HardwareSystemInsertVm>, HardwareSystemInsertVmValidator>();
builder.Services.AddTransient<IValidator<HardwareVersionVm>, HardwareVersionVmValidator>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
