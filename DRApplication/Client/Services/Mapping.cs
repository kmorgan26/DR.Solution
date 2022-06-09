using AutoMapper;
using DRApplication.Shared.Models.ConfigurationModels;
using DRApplication.Shared.Models.DeviceModels;
using DRApplication.Client.ViewModels;
namespace DRApplication.Client.Services;

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
        CreateMap<HardwareSystem, GenericListVm>().ReverseMap();

        CreateMap<HardwareVersionVm, HardwareVersion>();
        CreateMap<HardwareVersion, HardwareVersionInsertVm>().ReverseMap();
        CreateMap<HardwareVersion, GenericListVm>().ReverseMap();
        CreateMap<HardwareVersion, HardwareVersionVm>()
            .ForMember(dest => dest.VersionDateString,
                opts => opts.MapFrom(src => src.VersionDate.ToShortDateString()));

        CreateMap<HardwareConfig, HardwareConfigEditVm>().ReverseMap();
        CreateMap<HardwareConfig, HardwareConfigVm>().ReverseMap();
        CreateMap<HardwareConfig, GenericListVm>().ReverseMap();
        CreateMap<HardwareConfig, HardwareConfigInsertVm>().ReverseMap();

        CreateMap<HardwareVersionsConfig, HardwareVersionsConfigVm>().ReverseMap();
        CreateMap<HardwareVersionsConfig, HardwareVersionsConfigInsertVm>().ReverseMap();
        CreateMap<HardwareVersionsConfig, HardwareVersionsConfigEditVm>().ReverseMap();

        CreateMap<SoftwareSystem, SoftwareSystemInsertVm>().ReverseMap();
        CreateMap<SoftwareSystem, SoftwareSystemEditVm>().ReverseMap();
        CreateMap<SoftwareSystem, GenericListVm>().ReverseMap();
        CreateMap<SoftwareSystem, SoftwareSystemVm>().ReverseMap();

        CreateMap<SoftwareVersionVm, SoftwareVersion>();
        CreateMap<SoftwareVersion, SoftwareVersionInsertVm>().ReverseMap();
        CreateMap<SoftwareVersion, SoftwareVersionEditVm>().ReverseMap();
        CreateMap<SoftwareVersion, GenericListVm>().ReverseMap();
        CreateMap<SoftwareVersion, SoftwareVersionVm>()
            .ForMember(dest => dest.VersionDateString,
                opts => opts.MapFrom(src => src.VersionDate.ToShortDateString()));

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
        CreateMap<Device, DeviceVm>()
            .ForMember(dest => dest.Device,
                opts => opts.MapFrom(src => src.Name));
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
