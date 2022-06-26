﻿using DRApplication.Client.Interfaces;
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

        public Task<DeviceTypeVm> DeviceTypeVmFromDeviceTypeAsync(DeviceType deviceType)
        {
            throw new NotImplementedException();
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

        public async Task<IEnumerable<MaintainerVm>> MaintainerVmsFromMaintainersAsync(IEnumerable<Maintainer> maintainers)
        {
            var maintainerVms = maintainers.Select(m => new MaintainerVm
            {
                Id = m.Id,
                Maintainer = m.Name,
            });

            return await Task.Run(() => maintainerVms);
        }
    }
}
