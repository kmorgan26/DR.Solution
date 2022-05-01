using DRApplication.Server.Data;
using DRApplication.Shared.Models;
using DRApplication.Shared.Models.ConfigurationModels;
using DRApplication.Shared.Models.DeviceModels;
using Microsoft.AspNetCore.Http.Features;
using System.Text.Json.Serialization;

namespace DRApplication.Server
{
    public static class RegisterServiceDependencies
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContextFactory<FSTSSDatabaseContext>(
                options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DRConnectionString")));


            builder.Services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            builder.Services.AddTransient<EFRepository<Maintainer, FSTSSDatabaseContext>>();

            builder.Services.AddTransient<RepositoryEF<HardwareConfig, FSTSSDatabaseContext>>();
            builder.Services.AddTransient<EFRepository<DeviceType, FSTSSDatabaseContext>>();
            builder.Services.AddTransient<RepositoryEF<Device, FSTSSDatabaseContext>>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            return builder;
        }
    }
}
