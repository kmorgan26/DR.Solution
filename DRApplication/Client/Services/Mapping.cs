using AutoMapper;
using DRApplication.Client.ViewModels.ConfigurationViewModels;
using DRApplication.Client.ViewModels.DeviceTypeViewModels;
using DRApplication.Client.ViewModels.DeviceViewModels;
using DRApplication.Client.ViewModels.MaintainerViewModels;
using DRApplication.Client.ViewModels.Shared;
using DRApplication.Shared.Models.ConfigurationModels;
using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Services
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HardwareConfig, HardwareConfigEditVm>().ReverseMap();
            CreateMap<HardwareConfig, HardwareConfigVm>()
                .ForMember(dest => dest.DeviceTypeName,
                    opts => opts.MapFrom(src => src.DeviceType.Name));

            CreateMap<DeviceType, GenericListVm>().ReverseMap();
            CreateMap<DeviceType, DeviceTypeEditVm>().ReverseMap();

            CreateMap<DeviceType, DeviceTypeVm>().ReverseMap();

            CreateMap<Device, DeviceEditVm>().ReverseMap();
            CreateMap<Device, DeviceVm>()
                .ForMember(dest => dest.DeviceTypeName,
                    opts => opts.MapFrom(src => src.DeviceType.Name));

            CreateMap<Maintainer, GenericListVm>();
            CreateMap<Maintainer, MaintainerVm>().ReverseMap();

        }
    }
}
