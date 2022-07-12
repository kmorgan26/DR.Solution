using DRApplication.Client.Interfaces;

namespace DRApplication.Client.Services
{
    public class ManagerService : IManagerService
    {
        private readonly HttpClient _httpClient;
        public ManagerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public DeviceTypeVmManager DeviceTypeVmManager()
        {
            return new DeviceTypeVmManager(_httpClient);
        }
        public CurrentLoadVmManager CurrentLoadVmManager()
        {
            return new CurrentLoadVmManager(_httpClient);
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
        public DeviceVmManager DeviceVmManager()
        {
            return new DeviceVmManager(_httpClient);
        }
        public DeviceTypeManager DeviceTypeManager()
        {
            return new DeviceTypeManager(_httpClient);
        }
        public DrManager DrManager()
        {
            return new DrManager(_httpClient);
        }
        public HardwareSystemManager HardwareSystemManager()
        {
            return new HardwareSystemManager(_httpClient);
        }
        public HardwareVersionManager HardwareVersionManager()
        {
            return new HardwareVersionManager(_httpClient);
        }
        public HardwareConfigManager HardwareConfigManager()
        {
            return new HardwareConfigManager(_httpClient);
        }
        public IssueManager IssueManager()
        {
            return new IssueManager(_httpClient);
        }
        public LoadManager LoadManager()
        {
            return new LoadManager(_httpClient);
        }
        public LoadVmManager LoadVmManager()
        {
            return new LoadVmManager(_httpClient);
        }
        public MaintainerManager MaintainerManager()
        {
            return new MaintainerManager(_httpClient);
        }
        public MaintIssueManager MaintIssueManager()
        {
            return new MaintIssueManager(_httpClient);
        }
        public SoftwareSystemManager SoftwareSystemManager()
        {
            return new SoftwareSystemManager(_httpClient);
        }
        public SoftwareVersionManager SoftwareVersionManager()
        {
            return new SoftwareVersionManager(_httpClient);
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
