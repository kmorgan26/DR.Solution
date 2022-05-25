using AutoMapper;
using DRApplication.Client.ViewModels.Configuration;
using DRApplication.Client.ViewModels.Platform;
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
            CreateMap<HardwareSystem, HardwareSystemVm>().ReverseMap();
            CreateMap<HardwareSystem, HardwareSystemInsertVm>().ReverseMap();
            CreateMap<HardwareSystem, HardwareSystemEditVm>().ReverseMap();
            CreateMap<HardwareSystem, GenericListVm>().ReverseMap();

            CreateMap<HardwareVersion, HardwareVersionVm>().ReverseMap();
            CreateMap<HardwareVersion, HardwareVersionEditVm>().ReverseMap();
            CreateMap<HardwareVersion, HardwareVersionInsertVm>().ReverseMap();
            CreateMap<HardwareVersion, GenericListVm>().ReverseMap();

            CreateMap<HardwareConfig, HardwareConfigEditVm>().ReverseMap();
            CreateMap<HardwareConfig, HardwareConfigVm>().ReverseMap();
            CreateMap<HardwareConfig, GenericListVm>().ReverseMap();
            CreateMap<HardwareConfig, HardwareConfigInsertVm>().ReverseMap();

            CreateMap<HardwareVersionsConfig, HardwareVersionsConfigVm>().ReverseMap();
            CreateMap<HardwareVersionsConfig, HardwareVersionsConfigInsertVm>().ReverseMap();
            CreateMap<HardwareVersionsConfig, HardwareVersionsConfigEditVm>().ReverseMap();

            CreateMap<SoftwareSystem, SoftwareSystemVm>().ReverseMap();
            CreateMap<SoftwareSystem, SoftwareSystemInsertVm>().ReverseMap();
            CreateMap<SoftwareSystem, SoftwareSystemEditVm>().ReverseMap();
            CreateMap<SoftwareSystem, GenericListVm>().ReverseMap();

            CreateMap<SoftwareVersion, SoftwareVersionVm>().ReverseMap();
            CreateMap<SoftwareVersion, SoftwareVersionInsertVm>().ReverseMap();
            CreateMap<SoftwareVersion, SoftwareVersionEditVm>().ReverseMap();
            CreateMap<SoftwareVersion, GenericListVm>().ReverseMap();

            CreateMap<Load, LoadVm>().ReverseMap();
            CreateMap<Load, LoadEditVm>().ReverseMap();
            CreateMap<Load, LoadInsertVm>().ReverseMap();
            CreateMap<Load, GenericListVm>().ReverseMap();

            CreateMap<VersionsLoad, VersionsLoadVm>().ReverseMap();
            CreateMap<VersionsLoad, VersionsLoadInsertVm>().ReverseMap();
            CreateMap<VersionsLoad, VersionsLoadEditVm>().ReverseMap();

            CreateMap<DeviceType, GenericListVm>().ReverseMap();
            CreateMap<DeviceType, DeviceTypeEditVm>().ReverseMap();

            CreateMap<DeviceType, DeviceTypeVm>().ReverseMap();

            CreateMap<Device, DeviceEditVm>().ReverseMap();
            CreateMap<DeviceVm, Device>()
                .ForMember(dest => dest.Name,
                    opts => opts.MapFrom(src => src.Device));

            CreateMap<Maintainer, GenericListVm>();
            CreateMap<Maintainer, MaintainerVm>()
                .ForMember(dest => dest.Maintainer,
                    opts => opts.MapFrom(src => src.Name))
                .ReverseMap();
            CreateMap<Maintainer, MaintainerEditVm>().ReverseMap();

        }
    }
}
