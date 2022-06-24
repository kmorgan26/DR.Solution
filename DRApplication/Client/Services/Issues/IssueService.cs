using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Client.Helpers;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Services
{
    public class IssueService : IIssueService
    {
        private readonly IPlatformService _platformService;
        private readonly ManagerService _managerService;

        public IssueService(IPlatformService platformService, ManagerService managerService)
        {
            _platformService = platformService;
            _managerService = managerService;
        }

        public Task<int> InsertDrAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertIssueAsync(IssueInsertVm issueInsertVm)
        {
            var issueToInsert = IssueHelpers.GetIssueFromIssueInsertVm(issueInsertVm);

            var issue = await _managerService.IssueManager().InsertAsync(issueToInsert);
            return issue.Id;
        }

        public async Task<int> InsertMaintenanceIssueAsync(MaintenanceIssueInsertVm maintenanceIssueInsertVm)
        {
            //Before Inserting a Maintenance Issue, we need an IssueId after an Issue Insert
            var issueInsertVm = IssueHelpers.GetIssueInsertVmFromMaintenanceIssueVm(maintenanceIssueInsertVm);
            var issueId = await InsertIssueAsync(issueInsertVm);

            //we have the IssueId. Now insert the Maintenance Issue
            var maintIssueToInsert = new MaintIssue
            {
                ActionTaken = maintenanceIssueInsertVm.ActionTaken,
                CorrectiveActionId = maintenanceIssueInsertVm.CorrectiveActionId,
                IssueId = issueId,
                Pid = maintenanceIssueInsertVm.Pid
            };
            var maintIssue = await _managerService.MaintIssueManager().InsertAsync(maintIssueToInsert);

            //Need TO Insert into DeviceDiscovered

            await InsertDeviceDiscoveredAsync(maintenanceIssueInsertVm.DeviceId, issueId);

            return maintIssue.Id;

        }
        public async Task<IEnumerable<CorrectiveActionVm>> GetCorrectiveActionVmsAsync()
        {
            var correctiveActions = await _managerService.CorrectiveActionManager().GetAllAsync();

            var vms = correctiveActions.Select(c => new CorrectiveActionVm
            {
                Id = c.Id,
                Name = c.Name
            }).OrderBy(i => i.Name);

            return vms;
        }

        public async Task<int> InsertDeviceDiscoveredAsync(int deviceId, int issueId)
        {
            var deviceDiscoveredToInsert = new DeviceDiscovered
            {
                DeviceId = deviceId,
                IssueId = issueId
            };
            var deviceDiscovered = await _managerService.DeviceDiscoveredManager().InsertAsync(deviceDiscoveredToInsert);

            return deviceDiscovered.Id;
        }
    }
}
