using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Client.Helpers;
using DRApplication.Shared.Models;

namespace DRApplication.Client.Services
{
    public class IssueService : IIssueService
    {
        private readonly IManagerService _managerService;
        private readonly AppState _appState;

        public IssueService(IManagerService managerService, AppState appState)
        {
            _managerService = managerService;
            _appState = appState;
        }

        #region ---Inserts---
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

        #endregion

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

        /// <summary>
        /// This method is used to get the latest 5 issues inserted for the selected Device on the Maint Issues Entry Page
        /// </summary>
        public async Task<IEnumerable<MaintenanceIssueVm>> GetMaintenanceIssueVmsForEntryTableAsync()
        {
            try
            {

                //first get the selected DeviceVm
                var deviceVm = _appState.DeviceVm;

                //get correctiveActions
                var correctiveActions = await _managerService.CorrectiveActionManager().GetAllAsync();

                //get statuses
                

                //Get the DeviceDiscovered DTOs with that DeviceId (previous 10)
                var deviceDiscoveredFilter = await new FilterGenerator<DeviceDiscovered>().GetFilterWherePropertyEqualsValueAsync("DeviceId", deviceVm.Id);
                var devicesDiscoveredResponse = await _managerService.DeviceDiscoveredManager().GetAsync(deviceDiscoveredFilter);
                var devicesDiscovered = devicesDiscoveredResponse.Data;

                var issueIds = devicesDiscovered.Select(i => i.IssueId.ToString()).ToList();

                var issueFilter = await new FilterGenerator<Issue>().GetFilterForPropertyByListOfIdsAsync("Id", issueIds);
                var issueResponse = await _managerService.IssueManager().GetAsync(issueFilter);
                var issues = issueResponse.Data;


                //get the Maintenance Issues
                var maintIssueFilter = await new FilterGenerator<MaintIssue>().GetFilterForPropertyByListOfIdsAsync("Id", issueIds);
                var maintIssuesResponse = await _managerService.MaintIssueManager().GetAsync(maintIssueFilter);
                var maintIssues = maintIssuesResponse.Data;


                var maintIssueVms = issues.Select(i => new MaintenanceIssueVm
                {
                    IssueId = i.Id,
                    IssueDate = i.IssueDate,
                    DrType = i.DrTypeId == 1 ? "GOV" : "CNT",
                    SimStatus = i.SimStatusId == 12 ? "Deferred" : "Closed",
                    Description = i.Description,
                    ActionTaken = maintIssues.Where(m => m.IssueId == i.Id).FirstOrDefault().ActionTaken,
                    EnteredBy = i.EnteredBy,
                    Device = deviceVm.Device,
                    CorrectiveAction = correctiveActions
                        .Where(ca => ca.Id == maintIssues
                        .Where(m => m.IssueId == i.Id).FirstOrDefault().CorrectiveActionId).FirstOrDefault().Name,
                    Pid = maintIssues.Where(m => m.IssueId == i.Id).FirstOrDefault().Pid
                });

                if (maintIssueVms is not null)
                    return maintIssueVms;

                return new List<MaintenanceIssueVm>();
            }
            catch (Exception)
            {
                return new List<MaintenanceIssueVm>();
                throw;
            }
        }
    }
}
