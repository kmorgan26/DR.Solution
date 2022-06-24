namespace DRApplication.Client.Services
{
    public class ManagerService
    {
        private readonly HttpClient _httpClient;

        public ManagerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public DeviceManager DeviceManager()
        {
            return new DeviceManager(_httpClient);
        }
        public CorrectiveActionManager CorrectiveActionManager()
        {
            return new CorrectiveActionManager(_httpClient);
        }
        public DrManager DrManager()
        {
            return new DrManager(_httpClient);
        }
        public MaintIssueManager MaintIssueManager()
        {
            return new MaintIssueManager(_httpClient);
        }
        public IssueManager IssueManager()
        {
            return new IssueManager(_httpClient);
        }
        public DeviceDiscoveredManager DeviceDiscoveredManager()
        {
            return new DeviceDiscoveredManager(_httpClient);
        }

    }
}
