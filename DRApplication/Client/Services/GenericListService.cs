using DRApplication.Client.Enums;
using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Services
{
    public class GenericListService : IGenericListService
    {
        private readonly MaintainerManager _maintainerManager;
        private readonly DeviceTypeManager _deviceTypeManager;
        private readonly DeviceManager _deviceManager;

        public GenericListService(MaintainerManager maintainerManager, DeviceTypeManager deviceTypeManager, DeviceManager deviceManager)
        {
            _maintainerManager = maintainerManager;
            _deviceTypeManager = deviceTypeManager;
            _deviceManager = deviceManager;
        }
        public async Task<IEnumerable<GenericListVm>> GetGenericListVmsAsync(PlatformListType listType)
        {
            IEnumerable<GenericListVm> vms = new List<GenericListVm>();

            switch (listType)
            {
                case PlatformListType.Device:
                    var devices = await _deviceManager.GetAllAsync();
                    vms = devices.Select(i => new GenericListVm
                    {
                        Id = i.Id,
                        Name = i.Name
                    });
                    return vms;
                case PlatformListType.Platform:
                    var deviceTypes = await _deviceTypeManager.GetAllAsync();
                    vms = deviceTypes.Select(i => new GenericListVm
                    {
                        Id = i.Id,
                        Name = i.Name
                    });
                    return vms;
                case PlatformListType.Maintainer:
                    var maintainers = await _maintainerManager.GetAllAsync();
                    vms = maintainers.Select(i => new GenericListVm
                    {
                        Id = i.Id,
                        Name = i.Name
                    });
                    return vms;
                default:
                    return new List<GenericListVm>();
            }
        }
    }
}
