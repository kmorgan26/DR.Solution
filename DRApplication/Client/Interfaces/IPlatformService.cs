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

    Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsByMaintainerId(int id);

    Task<MaintainerVm> GetMaintainerVmById(int id);

    Task<DeviceType> GetDeviceTypeFromDeviceTypeVm(DeviceTypeVm deviceTypeVm); 

    Task<Device> GetDeviceFromDeviceVm(DeviceVm deviceVm);

    Task<int> InsertDeviceTypeFromDeviceTypeInsertVm(DeviceTypeInsertVm deviceTypeInsertVm);

    Task<bool> EditMaintainerFromMaintainerVm(MaintainerVm maintainerVm);

}
