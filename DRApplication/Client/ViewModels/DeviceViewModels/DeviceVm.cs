namespace DRApplication.Client.ViewModels.DeviceViewModels
{
    public class DeviceVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DeviceType { get; set; }
        public bool IsActive { get; set; }

    }
}
