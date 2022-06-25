namespace DRApplication.Client.Services
{
    public class ManagerService
    {
        private readonly HttpClient _httpClient;
        public ManagerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public AppState AppState()
        {
            return new AppState();
        }
        public CurrentLoadManager CurrentLoadManager()
        {
            return new CurrentLoadManager(_httpClient);
        }
        public CorrectiveActionManager CorrectiveActionManager()
        {
            return new CorrectiveActionManager(_httpClient);
        }
        public DeviceDiscoveredManager DeviceDiscoveredManager()
        {
            return new DeviceDiscoveredManager(_httpClient);
        }
        public DeviceManager DeviceManager()
        {
            return new DeviceManager(_httpClient);
        }
        public DrManager DrManager()
        {
            return new DrManager(_httpClient);
        }
        public IssueManager IssueManager()
        {
            return new IssueManager(_httpClient);
        }
        public LoadManager LoadManager()
        {
            return new LoadManager(_httpClient);
        }
        public MaintIssueManager MaintIssueManager()
        {
            return new MaintIssueManager(_httpClient);
        }
        public SpecificLoadManager SpecificLoadManager()
        {
            return new SpecificLoadManager(_httpClient);
        }
        public VersionsLoadManager VersionsLoadManager()
        {
            return new VersionsLoadManager(_httpClient);
        }
    }
}
