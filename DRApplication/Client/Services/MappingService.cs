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
    }
}
