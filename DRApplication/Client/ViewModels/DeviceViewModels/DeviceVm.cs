namespace DRApplication.Client.ViewModels.DeviceViewModels
{
    public class DeviceVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DeviceType { get; set; } = string.Empty;
        public bool IsActive { get; set; }

    }
}
