using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Services
{
    public class IssueService : IIssueService
    {
        private readonly IPlatformService _platformService;
        private readonly CorrectiveActionManager _correctiveActionManager;
        private readonly IssueManager _issueManager;
        private readonly DrManager _drManager;
        private readonly MaintainerManager _maintainerManager;

        public IssueService(IPlatformService platformService, CorrectiveActionManager correctiveActionManager, IssueManager issueManager, DrManager drManager, MaintainerManager maintainerManager)
        {
            _platformService = platformService;
            _correctiveActionManager = correctiveActionManager;
            _issueManager = issueManager;
            _drManager = drManager;
            _maintainerManager = maintainerManager;
        }

        public Task<int> InsertDrAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertIssueAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertMaintenanceIssueAsync(MaintenanceIssueInsertVm maintenanceIssueInsertVm)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<CorrectiveActionVm>> GetCorrectiveActionVmsAsync()
        {
            var correctiveActions = await _correctiveActionManager.GetAllAsync();

            var vms = correctiveActions.Select(c => new CorrectiveActionVm
            {
                Id = c.Id,
                Name = c.Name
            }).OrderBy(i => i.Name);

            return vms;
        }
    }
}
