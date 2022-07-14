using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;
namespace DRApplication.Client.Services;

public class MapperService : IMapperService
{

    #region --- Fields and Constructor ---

    private readonly IManagerService _managerService;
    private readonly ILoadHelpers _loadHelpers;
    public MapperService(IManagerService managerService, ILoadHelpers loadHelpers)
    {
        _managerService = managerService;
        _loadHelpers = loadHelpers;
    }

    #endregion

    #region --- async Platform Maps ---

    public async Task<DeviceVm> DeviceVmFromDeviceAsync(Device device)
    {
        var deviceType = await _managerService.DeviceTypeManager().GetByIdAsync(device.DeviceTypeId);

        var deviceVm = new DeviceVm
        {
            Id = device.Id,
            Device = device.Name,
            DeviceTypeId = device.DeviceTypeId,
            IsActive = device.IsActive,
            Platform = deviceType.Name
        };

        return deviceVm;
    }

    #endregion

    #region ---Platform Maps---

    public CurrentLoadEditVm CurrentLoadEditVmFromCurrentLoadVm(CurrentLoadVm currentLoadVm)
    {
        var currentLoadEditVm = new CurrentLoadEditVm
        {
            DeviceId = currentLoadVm.DeviceId,
            LoadId = currentLoadVm.LoadId,
            Id = currentLoadVm.Id
        };

        return currentLoadEditVm;
    }
    public CurrentLoad CurrentLoadFromCurrentLoadEditVm(CurrentLoadEditVm currentLoadEditVm)
    {
        var currentLoad = new CurrentLoad()
        {
            Id = currentLoadEditVm.Id,
            DeviceId = currentLoadEditVm.DeviceId,
            LoadId = currentLoadEditVm.LoadId
        };
        return currentLoad;
    }
    public Device DeviceFromDeviceInsertVm(DeviceInsertVm deviceInsertVm)
    {
        var device = new Device()
        {
            IsActive = deviceInsertVm.IsActive,
            DeviceTypeId = deviceInsertVm.DeviceTypeId,
            Name = deviceInsertVm.Device
        };
        return device;
    }
    public Device DeviceFromDeviceEditVm(DeviceEditVm deviceEditVm)
    {
        var device = new Device()
        {
            Id = deviceEditVm.Id,
            IsActive = deviceEditVm.IsActive,
            DeviceTypeId = deviceEditVm.DeviceTypeId,
            Name = deviceEditVm.Device
        };
        return device;
    }
    public DeviceEditVm DeviceEditVmFromDeviceVm(DeviceVm deviceVm)
    {
        var deviceEditVm = new DeviceEditVm
        {
            Id = deviceVm.Id,
            DeviceTypeId = deviceVm.DeviceTypeId,
            IsActive = deviceVm.IsActive,
            Device = deviceVm.Device,
        };

        return deviceEditVm;
    }
    public DeviceType DeviceTypeFromDeviceTypeEditVm(DeviceTypeEditVm deviceTypeEditVm)
    {
        var deviceType = new DeviceType()
        {
            Id = deviceTypeEditVm.Id,
            IsActive = deviceTypeEditVm.IsActive,
            MaintainerId = deviceTypeEditVm.MaintainerId,
            Name = deviceTypeEditVm.Platform
        };
        return deviceType;
    }
    public DeviceType DeviceTypeFromDeviceTypeInsertVm(DeviceTypeInsertVm deviceTypeInsertVm)
    {
        var deviceType = new DeviceType()
        {
            IsActive = deviceTypeInsertVm.IsActive,
            MaintainerId = deviceTypeInsertVm.MaintainerId,
            Name = deviceTypeInsertVm.Platform
        };

        return deviceType;
    }
    public DeviceTypeEditVm DeviceTypeEditVmFromDeviceTypeVm(DeviceTypeVm deviceTypeVm)
    {
        var deviceTypeEditVm = new DeviceTypeEditVm
        {
            Id = deviceTypeVm.Id,
            IsActive = deviceTypeVm.IsActive,
            MaintainerId = deviceTypeVm.MaintainerId,
            Platform = deviceTypeVm.Platform
        };

        return deviceTypeEditVm;
    }
    public Maintainer MaintainerFromMaintainerEditVm(MaintainerEditVm maintainerEditVm)
    {
        var maintainer = new Maintainer()
        {
            Id = maintainerEditVm.Id,
            Name = maintainerEditVm.Name
        };

        return maintainer;
    }
    public MaintainerVm MaintainerVmFromMaintainer(Maintainer maintainer)
    {
        var maintainerVm = new MaintainerVm()
        {
            Id = maintainer.Id,
            Maintainer = maintainer.Name
        };
        return maintainerVm;
    }
    public MaintainerEditVm MaintainerEditVmFromMaintainer(Maintainer maintainer)
    {
        var maintainerEditVm = new MaintainerEditVm()
        {
            Id = maintainer.Id,
            Name = maintainer.Name
        };
        return maintainerEditVm;
    }
    public async Task<IEnumerable<DeviceVm>> DeviceVmsFromDevicesAsync(IEnumerable<Device> devices)
    {
        var deviceTypes = await _managerService.DeviceTypeManager().GetAllAsync();

        var deviceVms = devices.Select(m => new DeviceVm
        {
            Id = m.Id,
            Device = m.Name,
            DeviceTypeId = m.DeviceTypeId,
            Platform = deviceTypes.Where(a => a.Id == m.DeviceTypeId).FirstOrDefault().Name,
            IsActive = m.IsActive
        }).OrderBy(i => i.Device); ;

        return deviceVms;
    }
    public IEnumerable<MaintainerVm> MaintainerVmsFromMaintainers(IEnumerable<Maintainer> maintainers)
    {
        var maintainerVms = maintainers.Select(m => new MaintainerVm
        {
            Id = m.Id,
            Maintainer = m.Name,
        });

        return maintainerVms;
    }

    #endregion

    #region --- Hardware Maps ---
    public HardwareConfig HardwareConfigFromHardwareConfigInsertVm(HardwareConfigInsertVm hardwareConfigInsertVm)
    {
        var hardwareConfig = new HardwareConfig
        {
            Name = hardwareConfigInsertVm.Name,
            DeviceTypeId = hardwareConfigInsertVm.DeviceTypeId
        };

        return hardwareConfig;
    }
    public HardwareConfig HardwareConfigFromHardwareConfigEditVm(HardwareConfigEditVm hardwareConfigEditVm)
    {
        var hardwareConfig = new HardwareConfig
        {
            Id = hardwareConfigEditVm.Id,
            Name = hardwareConfigEditVm.Name,
            DeviceTypeId = hardwareConfigEditVm.DeviceTypeId
        };

        return hardwareConfig;
    }
    public HardwareConfigVm HardwareConfigVmFromHardwareConfig(HardwareConfig hardwareConfig)
    {
        var hardwareConfigVm = new HardwareConfigVm
        {
            Id = hardwareConfig.Id,
            Name = hardwareConfig.Name,
            DeviceTypeId = hardwareConfig.DeviceTypeId
        };
        return hardwareConfigVm;
    }
    public HardwareConfigEditVm HardwareConfigEditVmFromHardwareConfigVm(HardwareConfigVm hardwareConfigVm)
    {
        var hardwareConfigEditVm = new HardwareConfigEditVm
        {
            Id = hardwareConfigVm.Id,
            Name = hardwareConfigVm.Name,
            DeviceTypeId = hardwareConfigVm.DeviceTypeId
        };
        return hardwareConfigEditVm;
    }
    public HardwareSystem HardwareSystemFromHardwareSystemVm(HardwareSystemVm hardwareSystemVm)
    {
        var hardwareSystem = new HardwareSystem
        {
            Id = hardwareSystemVm.Id,
            Name = hardwareSystemVm.Name
        };

        return hardwareSystem;
    }
    public HardwareSystem HardwareSystemFromHardwareSystemInsertVm(HardwareSystemInsertVm hardwareSystemInsertVm)
    {
        var hardwareSystem = new HardwareSystem
        {
            Name = hardwareSystemInsertVm.Name,
        };

        return hardwareSystem;
    }
    public HardwareSystem HardwareSystemFromHardwareSystemEditVm(HardwareSystemEditVm hardwareSystemEditVm)
    {
        var hardwareSystem = new HardwareSystem
        {
            Id = hardwareSystemEditVm.Id,
            Name = hardwareSystemEditVm.Name
        };

        return hardwareSystem;
    }
    public HardwareSystemVm HardwareSystemVmFromHardwareSystem(HardwareSystem hardwareSystem)
    {
        var hardwareSystemVm = new HardwareSystemVm
        {
            Id = hardwareSystem.Id,
            Name = hardwareSystem.Name
        };

        return hardwareSystemVm;
    }
    public HardwareSystemEditVm HardwareSystemEditVmFromHardwareSystem(HardwareSystem hardwareSystem)
    {
        var hardwareSystemEditVm = new HardwareSystemEditVm
        {
            Id = hardwareSystem.Id,
            Name = hardwareSystem.Name
        };

        return hardwareSystemEditVm;
    }
    public HardwareVersion HardwareVersionFromHardwareVersionVm(HardwareVersionVm hardwareVersionVm)
    {
        var hardwareVersion = new HardwareVersion
        {
            Id = hardwareVersionVm.Id,
            Name = hardwareVersionVm.Name,
            VersionDate = (DateTime)hardwareVersionVm.VersionDate,
            HardwareSystemId = hardwareVersionVm.HardwareSystemId
        };

        return hardwareVersion;
    }
    public HardwareVersion HardwareVersionFromHardwareVersionInsertVm(HardwareVersionInsertVm hardwareVersionInsertVm)
    {
        var hardwareVersion = new HardwareVersion
        {
            Name = hardwareVersionInsertVm.Name,
            HardwareSystemId = hardwareVersionInsertVm.HardwareSystemId,
            VersionDate = (DateTime)hardwareVersionInsertVm.VersionDate
        };

        return hardwareVersion;
    }
    public HardwareVersion HardwareVersionFromHardwareVersionEditVm(HardwareVersionEditVm hardwareVersionEditVm)
    {
        var hardwareVersion = new HardwareVersion
        {
            Id = hardwareVersionEditVm.Id,
            Name = hardwareVersionEditVm.Name,
            HardwareSystemId = hardwareVersionEditVm.HardwareSystemId,
            VersionDate = (DateTime)hardwareVersionEditVm.VersionDate
        };

        return hardwareVersion;
    }
    public HardwareVersionVm HardwareVersionVmFromHardwareVersion(HardwareVersion hardwareVersion)
    {
        var hardwareVersionVm = new HardwareVersionVm
        {
            Id = hardwareVersion.Id,
            Name = hardwareVersion.Name,
            HardwareSystemId = hardwareVersion.HardwareSystemId,
            VersionDate = hardwareVersion.VersionDate,
        };

        return hardwareVersionVm;
    }
    public HardwareVersionInsertVm HardwareVersionInsertVmFromHardwareVersionVm(HardwareVersionVm hardwareVersionVm)
    {
        var hardwareVersionInsertVm = new HardwareVersionInsertVm
        {
            HardwareSystemId = hardwareVersionVm.HardwareSystemId,
            Name = hardwareVersionVm.Name,
            VersionDate = hardwareVersionVm.VersionDate
        };

        return hardwareVersionInsertVm;
    }
    public HardwareVersionEditVm HardwareVersionEditVmFromHardwareVersion(HardwareVersion hardwareVersion)
    {
        var hardwareVersionEditVm = new HardwareVersionEditVm
        {
            Id = hardwareVersion.Id,
            Name = hardwareVersion.Name,
            HardwareSystemId = hardwareVersion.HardwareSystemId,
            VersionDate = hardwareVersion.VersionDate                
        };

        return hardwareVersionEditVm;
    }
    public HardwareVersionEditVm HardwareVersionEditVmFromHardwareVersionVm(HardwareVersionVm hardwareVersionVm)
    {
        var hardwareVersionEditVm = new HardwareVersionEditVm
        {
            Id = hardwareVersionVm.Id,
            Name = hardwareVersionVm.Name,
            HardwareSystemId = hardwareVersionVm.HardwareSystemId,
            VersionDate = hardwareVersionVm.VersionDate
        };

        return hardwareVersionEditVm;
    }
    public IEnumerable<HardwareConfigVm> HardwareConfigVmsFromHardwareConfigs(IEnumerable<HardwareConfig> hardwareConfigs)
    {
        var hardwareConfigVms = hardwareConfigs.Select(hwc => new HardwareConfigVm
        {
            Id = hwc.Id,
            Name = hwc.Name,
            DeviceTypeId = hwc.DeviceTypeId
        });

        return hardwareConfigVms;
    }
    public IEnumerable<HardwareSystemVm> HardwareSystemVmsFromHardwareSystems(IEnumerable<HardwareSystem> hardwareSystems)
    {
        var hardwareSystemVms = hardwareSystems.Select(hws => new HardwareSystemVm
        {
            Id = hws.Id,
            Name = hws.Name
        });
        return hardwareSystemVms;
    }

    #endregion

    #region ---async Software Maps ---
    public async Task<SoftwareSystemVm> SoftwareSystemVmFromSoftwareSystemAsync(SoftwareSystem softwareSystem)
    {
        var hardwareConfig = await _managerService.HardwareConfigManager().GetByIdAsync(softwareSystem.HardwareConfigId);

        var softwareSystemVm = new SoftwareSystemVm
        {
            Id = softwareSystem.Id,
            Name = softwareSystem.Name,
            HardwareConfigId = softwareSystem.HardwareConfigId,
            HardwareConfig = hardwareConfig.Name
        };

        return softwareSystemVm;
    }
    public async Task<IEnumerable<SoftwareSystemVm>> SoftwareSystemVmsFromSoftwareSystemsAsync(IEnumerable<SoftwareSystem> softwareSystems)
    {
        var hardwareConfigs = await _loadHelpers.GetHardwareConfigsFromSoftwareSystems(softwareSystems);

        var softwareSystemVms = softwareSystems.Select(ss => new SoftwareSystemVm
        {
            Id = ss.Id,
            Name = ss.Name,
            HardwareConfigId = ss.HardwareConfigId,
            HardwareConfig = hardwareConfigs.Where(i => i.Id == ss.HardwareConfigId).FirstOrDefault().Name
        });

        return softwareSystemVms;
    }

    #endregion

    #region --- Software Maps ---

    public SoftwareSystem SoftwareSystemFromSoftwareSystemVm(SoftwareSystemVm softwareSystemVm)
    {
        var softwareSystem = new SoftwareSystem
        {
            Name = softwareSystemVm.Name,
            HardwareConfigId = softwareSystemVm.HardwareConfigId,
            Id = softwareSystemVm.Id
        };

        return softwareSystem;
    }
    public SoftwareSystem SoftwareSystemFromSoftwareSystemInsertVm(SoftwareSystemInsertVm softwareSystemInsertVm)
    {
        var softwareSystem = new SoftwareSystem
        {
            Name = softwareSystemInsertVm.Name,
            HardwareConfigId = softwareSystemInsertVm.HardwareConfigId
        };

        return softwareSystem;
    }
    public SoftwareVersionVm SoftwareVersionVmFromSoftwareVersions(SoftwareVersion softwareVersion)
    {
        var softwareVersionVm = new SoftwareVersionVm
        {
            Id = softwareVersion.Id,
            Name = softwareVersion.Name,
            SoftwareSystemId = softwareVersion.SoftwareSystemId,
            VersionDate = softwareVersion.VersionDate
        };

        return softwareVersionVm;
    }
    public SoftwareVersion SoftwareVersionFromSoftwareVersionsInsertVm(SoftwareVersionInsertVm softwareVersionInsertVm)
    {
        var softwareVersion = new SoftwareVersion
        {
            Name = softwareVersionInsertVm.Name,
            SoftwareSystemId = softwareVersionInsertVm.SoftwareSystemId,
            VersionDate = (DateTime)softwareVersionInsertVm.VersionDate
        };

        return softwareVersion;
    }
    public SoftwareVersion SoftwareVersionFromSoftwareVersionVm(SoftwareVersionVm softwareVersionVm)
    {
        var softwareVersion = new SoftwareVersion
        {
            Name = softwareVersionVm.Name,
            SoftwareSystemId = softwareVersionVm.SoftwareSystemId,
            VersionDate = (DateTime)softwareVersionVm.VersionDate
        };

        return softwareVersion;
    }
    public IEnumerable<SoftwareVersionVm> SoftwareVersionVmsFromSoftwareVersionsAsync(IEnumerable<SoftwareVersion> softwareVersions)
    {
        var softwareVersionVms = softwareVersions.Select(sv => new SoftwareVersionVm
        {
            Id = sv.Id,
            Name = sv.Name,
            SoftwareSystemId = sv.SoftwareSystemId,
            VersionDate = sv.VersionDate
        });

        return softwareVersionVms;
    }

    #endregion

    #region --- Load Maps ---

    public LoadVm LoadVmFromLoad(Load load)
    {
        var loadVm = new LoadVm
        {
            Id = load.Id,
            HardwareConfigId = load.HardwareConfigId,
            IsAccepted = load.IsAccepted,
            Name = load.Name
        };

        return loadVm;
    }
    public Load LoadFromLoadVm(LoadVm loadVm)
    {
        var load = new Load
        {
            Id = loadVm.Id,
            Name = loadVm.Name,
            HardwareConfigId = loadVm.HardwareConfigId,
            IsAccepted = loadVm.IsAccepted
        };

        return load;
    }
    public Load LoadFromLoadInsertVm(LoadInsertVm loadInsertVm)
    {
        var load = new Load
        {
            IsAccepted = loadInsertVm.IsAccepted,
            Name = loadInsertVm.Name,
            HardwareConfigId = loadInsertVm.HardwareConfigId,
        };

        return load;
    }
    public SpecificLoad SpecificLoadFromSpecificLoadVm(SpecificLoadVm specificLoadVm)
    {
        var specificLoad = new SpecificLoad()
        {
            Id = specificLoadVm.Id,
            DeviceId = specificLoadVm.DeviceId,
            LoadId = specificLoadVm.LoadId
        };
        return specificLoad;
    }

    #endregion

    public async Task<IEnumerable<VersionsLoadVm>> VersionsLoadVmsFromVersionsLoadAsync(IEnumerable<VersionsLoad> versionsLoads)
    {
        var softwareVersions = await _loadHelpers.GetSoftwareVersionsFromVersionLoads(versionsLoads);
        var softwareSystems = await _loadHelpers.GetSoftwareSystemFromSoftwareVersionAsync(softwareVersions);

        var versionsLoadVms = versionsLoads.Select(vl => new VersionsLoadVm
        {
            Id = vl.Id,
            LoadId = vl.LoadId,
            SoftwareVersionId = vl.SoftwareVersionId,
            SoftwareVersionName = softwareVersions.Where(i => i.Id == vl.SoftwareVersionId).FirstOrDefault().Name,
            SoftwareSystemName = softwareSystems
                .Where(ss => ss.Id == softwareVersions
                .Where(sv => sv.Id == vl.SoftwareVersionId)
                .FirstOrDefault().SoftwareSystemId)
                .FirstOrDefault().Name
        });

        return versionsLoadVms;
    }

}