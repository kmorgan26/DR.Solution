namespace DRApplication.Client.ViewModels.Platform.DeviceViewModels
{
    public class DeviceCardVm
    {
        public int Id { get; set; }

        public string Device { get; set; } = string.Empty;

        public string Platform { get; set; } = string.Empty;

        public int DeviceTypeId { get; set; }

        public bool IsActive { get; set; }

        public string CurrentLoadName { get; set; } = string.Empty;

    }
}
