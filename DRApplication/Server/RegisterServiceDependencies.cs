using DRApplication.Server.Data;
using DRApplication.Shared.Models;
using Microsoft.AspNetCore.Http.Features;
using System.Text.Json.Serialization;

namespace DRApplication.Server
{
    public static class RegisterServiceDependencies
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            builder.Services.AddTransient(s => new DapperRepository<CurrentLoad>(
               builder.Configuration.GetConnectionString("DRConnectionString")));

            builder.Services.AddTransient(s => new DapperRepository<Device>(
                builder.Configuration.GetConnectionString("DRConnectionString")));

            builder.Services.AddTransient(s => new DapperRepository<DeviceType>(
                builder.Configuration.GetConnectionString("DRConnectionString")));

            builder.Services.AddTransient(s => new DapperRepository<HardwareConfig>(
                builder.Configuration.GetConnectionString("DRConnectionString")));

            builder.Services.AddTransient(s => new DapperRepository<HardwareSystem>(
                builder.Configuration.GetConnectionString("DRConnectionString")));

            builder.Services.AddTransient(s => new DapperRepository<HardwareVersion>(
               builder.Configuration.GetConnectionString("DRConnectionString")));

            builder.Services.AddTransient(s => new DapperRepository<HardwareVersionsConfig>(
               builder.Configuration.GetConnectionString("DRConnectionString")));

            builder.Services.AddTransient(s => new DapperRepository<Load>(
               builder.Configuration.GetConnectionString("DRConnectionString")));

            builder.Services.AddTransient(s => new DapperRepository<Maintainer>(
                builder.Configuration.GetConnectionString("DRConnectionString")));

            builder.Services.AddTransient(s => new DapperRepository<SpecificLoad>(
               builder.Configuration.GetConnectionString("DRConnectionString")));

            builder.Services.AddTransient(s => new DapperRepository<SoftwareSystem>(
               builder.Configuration.GetConnectionString("DRConnectionString")));

            builder.Services.AddTransient(s => new DapperRepository<SoftwareVersion>(
               builder.Configuration.GetConnectionString("DRConnectionString")));

            builder.Services.AddTransient(s => new DapperRepository<VersionsLoad>(
               builder.Configuration.GetConnectionString("DRConnectionString")));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            return builder;
        }
    }
}
