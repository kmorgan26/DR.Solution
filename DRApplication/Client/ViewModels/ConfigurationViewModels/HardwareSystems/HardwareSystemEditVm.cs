using System.ComponentModel.DataAnnotations;

namespace DRApplication.Client.ViewModels.ConfigurationViewModels.HardwareSystems
{
    public class HardwareSystemEditVm
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 50, ErrorMessage = "Hardware System cannot be more than 50 characters long")]
        public string Name { get; set; } = string.Empty;
    }
}
