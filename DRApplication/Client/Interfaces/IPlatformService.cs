using DRApplication.Shared.Enums;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Interfaces;

public interface IPlatformService
{
    Task<IEnumerable<MaintainerVm>> GetMaintainerVmsAsync();
    Task<IEnumerable<DeviceVm>> GetDeviceVmsFromDeviceTypeId(int id);
    Task<IEnumerable<DeviceVm>> GetDeviceVmsByListOfIds(List<string> csvids);
    Task<IEnumerable<DeviceVm>> GetDeviceVmsFromDeviceListAsync(IEnumerable<Device> devices);
    Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsAsync();    
    Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsByMaintainerId(int id);
    Task<DeviceTypeVm> GetDeviceTypeVmById(int id);
    Task<DeviceVm> GetDeviceVmById(int id);
    Task<DeviceVm> GetDeviceVmFromDeviceAsync(Device device);
    Task<MaintainerVm> GetMaintainerVmById(int id);
    Task<DeviceType> GetDeviceTypeFromDeviceTypeVm(DeviceTypeVm deviceTypeVm); 
    Task<Device> GetDeviceFromDeviceVm(DeviceVm deviceVm);
    Task<Device> GetDeviceFromDeviceInsertVm(DeviceInsertVm deviceInsertVm);
    Task<int> InsertDeviceTypeFromDeviceTypeInsertVm(DeviceTypeInsertVm deviceTypeInsertVm);
    Task<bool> EditMaintainerFromMaintainerVm(MaintainerVm maintainerVm);
}