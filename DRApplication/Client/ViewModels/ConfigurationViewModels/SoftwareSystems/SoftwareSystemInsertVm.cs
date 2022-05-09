using System.ComponentModel.DataAnnotations;

namespace DRApplication.Client.ViewModels.ConfigurationViewModels.SoftwareSystems
{
    public class SoftwareSystemInsertVm
    {
        [Required]
        [Range(1, 50, ErrorMessage = "Software System Name cannot be more than 50 characters long")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, 100, ErrorMessage = "Please Select a Hardware Configuration")]
        public int HardwareConfigId { get; set; }

    }
}
