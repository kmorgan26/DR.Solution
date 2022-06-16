namespace DRApplication.Client.ViewModels
{
    public class SpecificLoadVm
    {
        public int Id { get; set; } = 0;

        public int LoadId { get; set; } = 0;

        public int DeviceId { get; set; } = 0;

        public string LoadName { get; set; } = string.Empty;

        public string Device { get; set; } = string.Empty;
    }
}
