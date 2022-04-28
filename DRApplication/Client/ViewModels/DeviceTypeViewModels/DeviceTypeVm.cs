namespace DRApplication.Client.ViewModels.DeviceTypeViewModels
{
    public class DeviceTypeVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Maintainer { get; set; }
        public bool IsActive { get; set; }
    }
}
