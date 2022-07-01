using DRApplication.Shared.Enums;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Interfaces;

public interface IPlatformService
{
    Task<IEnumerable<MaintainerVm>> GetMaintainerVmsAsync();
    Task<IEnumerable<DeviceVm>> GetDeviceVmsFromDeviceTypeId(int id);
    Task<IEnumerable<DeviceVm>> GetDeviceVmsByListOfIds(List<string> csvids);
    Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsAsync();    
    Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsByMaintainerId(int id);
    Task<DeviceTypeVm> GetDeviceTypeVmById(int id);
    Task<DeviceTypeEditVm> GetDeviceTypeEditVmByIdAsync(int id);
    Task<DeviceVm> GetDeviceVmById(int id);
    Task<MaintainerVm> GetMaintainerVmById(int id);
    Task<MaintainerEditVm> GetMaintainerEditVmById(int id);
    Task<int> InsertDeviceTypeFromDeviceTypeInsertVm(DeviceTypeInsertVm deviceTypeInsertVm);
    Task<bool> UpdateMaintainerFromMaintainerEditVm(MaintainerEditVm maintainerEditVm);
}