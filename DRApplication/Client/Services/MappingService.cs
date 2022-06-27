using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Services
{
    public class MapperService : IMapperService
    {
        private readonly ManagerService _managerService;

        public MapperService(ManagerService managerService)
        {
            _managerService = managerService;
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
            var deviceType = await _managerService.DeviceTypeManager().GetByIdAsync(device.Id);

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
    }
}