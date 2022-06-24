using DRApplication.Client.ViewModels;
namespace DRApplication.Client.Interfaces;

public interface IIssueService
{
    Task<int> InsertIssueAsync(IssueInsertVm issueInsertVm);
    Task<int> InsertMaintenanceIssueAsync(MaintenanceIssueInsertVm maintenanceIssueInsertVm);
    Task<int> InsertDrAsync();
    Task<int> InsertDeviceDiscoveredAsync(int deviceId, int issueId);
    Task<IEnumerable<CorrectiveActionVm>> GetCorrectiveActionVmsAsync();

}
