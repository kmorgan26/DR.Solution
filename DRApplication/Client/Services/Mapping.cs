using AutoMapper;
using DRApplication.Client.ViewModels.ConfigurationViewModels.HardwareConfigs;
using DRApplication.Client.ViewModels.ConfigurationViewModels.HardwareSystems;
using DRApplication.Client.ViewModels.ConfigurationViewModels.HardwareVersions;
using DRApplication.Client.ViewModels.DeviceTypeViewModels;
using DRApplication.Client.ViewModels.DeviceViewModels;
using DRApplication.Client.ViewModels.MaintainerViewModels;
using DRApplication.Client.ViewModels.Shared;
using DRApplication.Shared.Models.ConfigurationModels;
using DRApplication.Shared.Models.DeviceModels;
using DRApplication.Client.ViewModels.ConfigurationViewModels.HardwareVersionsConfigs;

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
            CreateMap<HardwareVersion, GenericListVm>().ReverseMap();

            CreateMap<HardwareConfig, HardwareConfigEditVm>().ReverseMap();
            CreateMap<HardwareConfig, HardwareConfigVm>().ReverseMap();
            CreateMap<HardwareConfig, GenericListVm>().ReverseMap();
            CreateMap<HardwareConfig, HardwareConfigInsertVm>().ReverseMap();

            CreateMap<HardwareVersionsConfig, HardwareVersionsConfigVm>().ReverseMap();
            CreateMap<HardwareVersionsConfig, HardwareVersionsConfigInsertVm>().ReverseMap();


            CreateMap<DeviceType, GenericListVm>().ReverseMap();
            CreateMap<DeviceType, DeviceTypeEditVm>().ReverseMap();

            CreateMap<DeviceType, DeviceTypeVm>().ReverseMap();

            CreateMap<Device, DeviceEditVm>().ReverseMap();
            CreateMap<Device, DeviceVm>().ReverseMap();

            CreateMap<Maintainer, GenericListVm>();
            CreateMap<Maintainer, MaintainerVm>().ReverseMap();
            CreateMap<Maintainer, MaintainerEditVm>().ReverseMap();

        }
    }
}
