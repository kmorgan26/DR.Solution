using DRApplication.Shared.Enums;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Interfaces;

public interface IPlatformService
{
    
    Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsAsync();
    
    Task<IEnumerable<MaintainerVm>> GetMaintainerVmsAsync();

    Task<IEnumerable<DeviceVm>> GetDeviceVmsFromDeviceListAsync(IEnumerable<Device> devices);
    
    Task<IEnumerable<DeviceVm>> GetDeviceVmsFromDevicTypeId(int id);

    Task<DeviceTypeVm> GetDeviceTypeVmFromGenericVm(GenericListVm genericListVm);

    Task<DeviceTypeVm> GetDeviceTypeVmById(int id);


}
