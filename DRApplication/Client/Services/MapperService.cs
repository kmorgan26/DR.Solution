﻿using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Services
{
    public class MapperService : IMapperService
    {
        private readonly ManagerService _managerService;
        private readonly ILoadHelpers _loadHelpers;

        public MapperService(ManagerService managerService, ILoadHelpers loadHelpers)
        {
            _managerService = managerService;
            _loadHelpers = loadHelpers;
        }
        public async Task<Device> DeviceFromDeviceInsertVmAsync(DeviceInsertVm deviceInsertVm)
        {
            var device = new Device()
            {
                IsActive = deviceInsertVm.IsActive,
                DeviceTypeId = deviceInsertVm.DeviceTypeId,
                Name = deviceInsertVm.Name
            };
            return await Task.Run(() => device);
        }
        public async Task<Device> DeviceFromDeviceVmAsync(DeviceVm deviceVm)
        {
            var device = new Device()
            {
                Id = deviceVm.Id,
                IsActive = deviceVm.IsActive,
                DeviceTypeId = deviceVm.DeviceTypeId,
                Name = deviceVm.Device
            };
            return await Task.Run(() => device);
        }
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
        public async Task<DeviceType> DeviceTypeFromDeviceTypeVmAsync(DeviceTypeVm deviceTypeVm)
        {
            var deviceType = new DeviceType()
            {
                Id = deviceTypeVm.Id,
                IsActive = deviceTypeVm.IsActive,
                MaintainerId = deviceTypeVm.MaintainerId,
                Name = deviceTypeVm.Platform
            };
            return await Task.Run(() => deviceType);
        }
        public async Task<DeviceType> DeviceTypeFromDeviceTypeInsertVmAsync(DeviceTypeInsertVm deviceTypeInsertVm)
        {
            var deviceType = new DeviceType()
            {
                IsActive = deviceTypeInsertVm.IsActive,
                MaintainerId = deviceTypeInsertVm.MaintainerId,
                Name = deviceTypeInsertVm.Name
            };

            return await Task.Run(() => deviceType);
        }
        public async Task<DeviceTypeVm> DeviceTypeVmFromDeviceTypeAsync(DeviceType deviceType)
        {
            var maintainer = await _managerService.MaintainerManager().GetByIdAsync(deviceType.MaintainerId);

            var deviceTypeVm = new DeviceTypeVm
            {
                Id = deviceType.Id,
                IsActive = deviceType.IsActive,
                MaintainerId = deviceType.MaintainerId,
                Platform = deviceType.Name,
                Maintainer = maintainer.Name
            };
            return await Task.Run(() => deviceTypeVm);
        }
        public async Task<Maintainer> MaintainerFromMaintainerVmAsync(MaintainerVm maintainerVm)
        {
            var maintainer = new Maintainer()
            {
                Id = maintainerVm.Id,
                Name = maintainerVm.Maintainer
            };

            return await Task.Run(() => maintainer);
        }
        public async Task<MaintainerVm> MaintainerVmFromMaintainerAsync(Maintainer maintainer)
        {
            var maintainerVm = new MaintainerVm()
            {
                Id = maintainer.Id,
                Maintainer = maintainer.Name
            };
            return await Task.Run(() => maintainerVm);
        }
        public async Task<HardwareSystem> HardwareSystemFromHardwareSystemVmAsync(HardwareSystemVm hardwareSystemVm)
        {
            var hardwareSystem = new HardwareSystem
            {
                Id = hardwareSystemVm.Id,
                Name = hardwareSystemVm.Name
            };

            return await Task.Run(() => hardwareSystem);
        }
        public async Task<HardwareSystem> HardwareSystemFromHardwareSystemInsertVm(HardwareSystemInsertVm hardwareSystemInsertVm)
        {
            var hardwareSystem = new HardwareSystem
            {
                Name = hardwareSystemInsertVm.Name,
            };

            return await Task.Run(() => hardwareSystem);
        }
        public async Task<HardwareSystemVm> HardwareSystemVmFromHardwareSystemAsync(HardwareSystem hardwareSystem)
        {
            var hardwareSystemVm = new HardwareSystemVm
            {
                Id = hardwareSystem.Id,
                Name = hardwareSystem.Name
            };

            return await Task.Run(() => hardwareSystemVm);
        }
        public async Task<HardwareConfigVm> HardwareConfigVmFromHardwareConfigAsync(HardwareConfig hardwareConfig)
        {
            var hardwareConfigVm = new HardwareConfigVm
            {
                Id = hardwareConfig.Id,
                Name = hardwareConfig.Name,
                DeviceTypeId = hardwareConfig.DeviceTypeId
            };
            return await Task.Run(() => hardwareConfigVm);
        }
        public async Task<HardwareConfig> HardwareConfigFromHardwareConfigInsertVmAsync(HardwareConfigInsertVm hardwareConfigInsertVm)
        {
            var hardwareConfig = new HardwareConfig
            {
                Name = hardwareConfigInsertVm.Name,
                DeviceTypeId = hardwareConfigInsertVm.DeviceTypeId
            };

            return await Task.Run(() => hardwareConfig);
        }
        public async Task<HardwareVersionVm> HardwareVersionVmFromHardwareVersionsAsync(HardwareVersion hardwareVersion)
        {
            var hardwareVersionVm = new HardwareVersionVm
            {
                Id = hardwareVersion.Id,
                Name = hardwareVersion.Name,
                HardwareSystemId = hardwareVersion.HardwareSystemId,
                VersionDate = hardwareVersion.VersionDate,
                VersionDateString = hardwareVersion.VersionDate.ToShortDateString()
            };

            return await Task.Run(() => hardwareVersionVm);
        }
        public async Task<IEnumerable<DeviceVm>> DeviceVmsFromDevicesAsync(IEnumerable<Device> devices)
        {
            var deviceTypes = await _managerService.DeviceTypeManager().GetAllAsync();

            var vms = devices.Select(m => new DeviceVm
            {
                Id = m.Id,
                Device = m.Name,
                DeviceTypeId = m.DeviceTypeId,
                Platform = deviceTypes.Where(a => a.Id == m.DeviceTypeId).FirstOrDefault().Name,
                IsActive = m.IsActive
            }).OrderBy(i => i.Device); ;

            return vms;
        }
        public async Task<IEnumerable<DeviceTypeVm>> DeviceTypeVmsFromDeviceTypesAsync(IEnumerable<DeviceType> deviceTypes)
        {
            var maintainers = await _managerService.MaintainerManager().GetAllAsync();

            var deviceTypeVms = deviceTypes.Select(i => new DeviceTypeVm()
            {
                Id = i.Id,
                IsActive = i.IsActive,
                MaintainerId = i.MaintainerId,
                Platform = i.Name,
                Maintainer = maintainers.Where(m => m.Id == i.MaintainerId).FirstOrDefault().Name
            }).OrderBy(i => i.Platform);

            return deviceTypeVms;
        }
        public async Task<IEnumerable<MaintainerVm>> MaintainerVmsFromMaintainersAsync(IEnumerable<Maintainer> maintainers)
        {
            var maintainerVms = maintainers.Select(m => new MaintainerVm
            {
                Id = m.Id,
                Maintainer = m.Name,
            });

            return await Task.Run(() => maintainerVms);
        }
        public async Task<IEnumerable<HardwareSystemVm>> HardwareSystemVmsFromHardwareSystemsAsync(IEnumerable<HardwareSystem> hardwareSystems)
        {
            var hardwareSystemVms = hardwareSystems.Select(hws => new HardwareSystemVm
            {
                Id = hws.Id,
                Name = hws.Name
            });
            return await Task.Run(() => hardwareSystemVms);
        }
        public async Task<IEnumerable<HardwareVersionVm>> HardwareVersionVmsFromHardwareVersionsAsync(IEnumerable<HardwareVersion> hardwareVersions)
        {
            var hardwareVersionVms = hardwareVersions.Select(hwv => new HardwareVersionVm
            {
                Id = hwv.Id,
                Name = hwv.Name,
                VersionDate = hwv.VersionDate,
                HardwareSystemId = hwv.HardwareSystemId,
                VersionDateString = hwv.VersionDate.ToShortDateString()
            });
            return await Task.Run(()=> hardwareVersionVms);
        }
        public async Task<IEnumerable<HardwareConfigVm>> HardwareConfigVmsFromHardwareConfigsAsync(IEnumerable<HardwareConfig> hardwareConfigs)
        {
            var hardwareConfigVms = hardwareConfigs.Select(hwc => new HardwareConfigVm
            {
                Id = hwc.Id,
                Name = hwc.Name,
                DeviceTypeId = hwc.DeviceTypeId
            });

            return await Task.Run(() => hardwareConfigVms);
        }
        public async Task<HardwareConfig> HardwareConfigFromHardwareConfigVmAsync(HardwareConfigVm hardwareConfigVm)
        {
            var hardwareConfig = new HardwareConfig
            {
                Id = hardwareConfigVm.Id,
                Name = hardwareConfigVm.Name,
                DeviceTypeId = hardwareConfigVm.DeviceTypeId
            };

            return await Task.Run(() => hardwareConfig);
        }
        public async Task<HardwareVersion> HardwareVersionFromHardwareVersionVmAsync(HardwareVersionVm hardwareVersionVm)
        {
            var hardwareVersion = new HardwareVersion
            {
                Id = hardwareVersionVm.Id,
                Name = hardwareVersionVm.Name,
                VersionDate = (DateTime)hardwareVersionVm.VersionDate,
                HardwareSystemId = hardwareVersionVm.HardwareSystemId
            };

            return await Task.Run(() => hardwareVersion);
        }
        public async Task<HardwareVersion> HardwareVersionFromHardwareVersionInsertVmAsync(HardwareVersionInsertVm hardwareVersionInsertVm)
        {
            var hardwareVersion = new HardwareVersion
            {
                Name = hardwareVersionInsertVm.Name,
                HardwareSystemId = hardwareVersionInsertVm.HardwareSystemId,
                VersionDate = (DateTime)hardwareVersionInsertVm.VersionDate
            };

            return await Task.Run(() => hardwareVersion);
        }
        public async Task<SoftwareSystem> SoftwareSystemFromSoftwareSystemVmAsync(SoftwareSystemVm softwareSystemVm)
        {
            var softwareSystem = new SoftwareSystem
            {
                Name = softwareSystemVm.Name,
                HardwareConfigId = softwareSystemVm.HardwareConfigId,
                Id = softwareSystemVm.Id
            };

            return await Task.Run(() => softwareSystem);
        }
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

            return await Task.Run(() => softwareSystemVm);
        }
        public async Task<SoftwareSystem> SoftwareSystemFromSoftwareSystemInsertVmAsync(SoftwareSystemInsertVm softwareSystemInsertVm)
        {
            var softwareSystem = new SoftwareSystem
            {
                Name = softwareSystemInsertVm.Name,
                HardwareConfigId = softwareSystemInsertVm.HardwareConfigId
            };

            return await Task.Run(() => softwareSystem);
        }
        public async Task<SoftwareVersionVm> SoftwareVersionVmFromSoftwareVersionsAsync(SoftwareVersion softwareVersion)
        {
            var softwareVersionVm = new SoftwareVersionVm
            {
                Id = softwareVersion.Id,
                Name = softwareVersion.Name,
                SoftwareSystemId = softwareVersion.SoftwareSystemId,
                VersionDate = softwareVersion.VersionDate,
                VersionDateString = softwareVersion.VersionDate.ToShortDateString()
            };

            return await Task.Run(() => softwareVersionVm);
        }
        public async Task<SoftwareVersion> SoftwareVersionFromSoftwareVersionsInsertVmAsync(SoftwareVersionInsertVm softwareVersionInsertVm)
        {
            var softwareVersion = new SoftwareVersion
            {
                Name = softwareVersionInsertVm.Name,
                SoftwareSystemId = softwareVersionInsertVm.SoftwareSystemId,
                VersionDate = (DateTime)softwareVersionInsertVm.VersionDate
            };

            return await Task.Run(() => softwareVersion);
        }
        public async Task<SoftwareVersion> SoftwareVersionFromSoftwareVersionVmAsync(SoftwareVersionVm softwareVersionVm)
        {
            var softwareVersion = new SoftwareVersion
            {
                Name = softwareVersionVm.Name,
                SoftwareSystemId = softwareVersionVm.SoftwareSystemId,
                VersionDate = (DateTime)softwareVersionVm.VersionDate
            };

            return await Task.Run(() => softwareVersion);
        }
        public async Task<LoadVm> LoadVmFromLoadAsync(Load load)
        {
            var loadVm = new LoadVm
            {
                Id = load.Id,
                HardwareConfigId = load.HardwareConfigId,
                IsAccepted = load.IsAccepted,
                Name = load.Name
            };

            return await Task.Run(() => loadVm);
        }
        public async Task<Load> LoadFromLoadVm(LoadVm loadVm)
        {
            var load = new Load
            {
                Id = loadVm.Id,
                Name = loadVm.Name,
                HardwareConfigId = loadVm.HardwareConfigId,
                IsAccepted = loadVm.IsAccepted
            };

            return await Task.Run(() => load);
        }
        public async Task<Load> LoadFromLoadInsertVm(LoadInsertVm loadInsertVm)
        {
            var load = new Load
            {
                IsAccepted = loadInsertVm.IsAccepted,
                Name = loadInsertVm.Name,
                HardwareConfigId = loadInsertVm.HardwareConfigId,
            };

            return await Task.Run(() => load);
        }
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
        public async Task<IEnumerable<LoadVm>> LoadVmsFromLoads(IEnumerable<Load> loads)
        {
            var loadVms = loads.Select(l => new LoadVm
            {
                Id = l.Id,
                Name = l.Name,
                HardwareConfigId = l.HardwareConfigId,
                IsAccepted = l.IsAccepted
            });

            return await Task.Run(() => loadVms);
        }
        public async Task<IEnumerable<SoftwareVersionVm>> SoftwareVersionVmsFromSoftwareVersionsAsync(IEnumerable<SoftwareVersion> softwareVersions)
        {
            var softwareVersionVms = softwareVersions.Select(sv => new SoftwareVersionVm
            {
                Id = sv.Id,
                Name = sv.Name,
                SoftwareSystemId = sv.SoftwareSystemId,
                VersionDate = sv.VersionDate,
                VersionDateString = sv.VersionDate.ToShortDateString()
            });

            return await Task.Run(()=> softwareVersionVms);
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
    }
}