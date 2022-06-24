using DRApplication.Client.ViewModels;
namespace DRApplication.Client.Interfaces;

public interface IIssueService
{
    Task<int> InsertIssueAsync();
    Task<int> InsertMaintenanceIssueAsync(MaintenanceIssueInsertVm maintenanceIssueInsertVm);
    Task<int> InsertDrAsync();
    Task<IEnumerable<CorrectiveActionVm>> GetCorrectiveActionVmsAsync();

}
