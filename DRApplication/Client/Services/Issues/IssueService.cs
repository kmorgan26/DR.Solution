using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Client.Helpers;
using DRApplication.Shared.Models;
using DRApplication.Shared.Requests;

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
        /// This is the View Model for the Maintenance Entry Form used by Operations
        /// This is the Table that is displayed below the form and shows the most recent 5
        /// entries so users can see data populate as they make entries
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MaintenanceIssueVm>> GetMaintenanceIssueVmsForEntryTableAsync()
        {
            AdhocRequest adhocRequest = new AdhocRequest
            {
                Url = "adhoc/listofvms",
                Query = $"SELECT TOP 5 i.Id[IssueId], dt.Name[DrType], ss.Name[SimStatus], i.Description, i.IssueDate, mi.Pid[PID], ca.Name[CorrectiveAction], mi.ActionTaken " +
                        $"FROM Issues i " +
                        $"INNER JOIN DrTypes dt ON dt.Id = i.DrTypeId " +
                        $"INNER JOIN SimStatuses ss ON ss.Id = i.SimStatusId " +
                        $"INNER JOIN MaintIssues mi ON mi.IssueId = i.Id " +
                        $"INNER JOIN CorrectiveActions ca ON ca.Id = mi.CorrectiveActionId " +
                        $"INNER JOIN DeviceDiscovered dd ON dd.IssueId = i.Id " +
                        $"WHERE dd.DeviceId = @deviceId " +
                        $"ORDER BY i.Id DESC ",
                Parameters = new Dictionary<string, int> { { "deviceId", _appState.DeviceVm.Id } }
            };
            return await _managerService.MaintIssueVmManager().Get(adhocRequest);
        }
    }
}
