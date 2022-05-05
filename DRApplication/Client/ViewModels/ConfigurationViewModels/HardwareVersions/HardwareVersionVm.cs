using System.ComponentModel.DataAnnotations;

namespace DRApplication.Client.ViewModels.ConfigurationViewModels.HardwareVersions
{
    public class HardwareVersionVm
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        [Display(Name = "Hardware Version")]
        public string HardwareSystemName { get; set; }
        
        public DateTime VersionDate { get; set; }

    }
}
