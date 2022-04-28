namespace DRApplication.Client.ViewModels.DeviceTypeViewModels
{
    public class DeviceTypeVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Maintainer { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
