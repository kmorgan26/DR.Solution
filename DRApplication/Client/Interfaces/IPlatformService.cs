using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Interfaces;

//TODO: Modify the DeviceVmsByListOfIds to use SQL Statement with IN clause
public interface IPlatformService
{
    Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsAsync();
    Task<IEnumerable<DeviceTypeVm>> GetDeviceTypeVmsByMaintainerIdAsync(int id);
    Task<IEnumerable<DeviceVm>> GetDeviceVmByDeviceTypeIdAsync(int deviceTypeId);
    Task<IEnumerable<MaintainerVm>> GetMaintainerVmsAsync();
    Task<IEnumerable<DeviceVm>> GetDeviceVmsByListOfIds(List<string> csvids);

    Task<DeviceTypeVm> GetDeviceTypeVmByIdAsync(int id);
    Task<DeviceVm> GetDeviceVmByIdAsync(int id);
    Task<MaintainerVm> GetMaintainerVmById(int id);
    Task<MaintainerEditVm> GetMaintainerEditVmById(int id);
    Task<int> InsertDeviceTypeFromDeviceTypeInsertVm(DeviceTypeInsertVm deviceTypeInsertVm);
    Task<int> InsertDeviceFromDeviceInsertVm(DeviceInsertVm deviceTypeInsertVm);
    Task<bool> UpdateMaintainerFromMaintainerEditVm(MaintainerEditVm maintainerEditVm);
}