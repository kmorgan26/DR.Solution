namespace DRApplication.Client.ViewModels.ConfigurationViewModels.SoftwareSystems
{
    public class SoftwareSystemVm
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public int HardwareConfigId { get; set; }

    }
}
