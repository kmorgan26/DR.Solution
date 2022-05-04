using System.ComponentModel.DataAnnotations;

namespace DRApplication.Client.ViewModels.DeviceTypeViewModels
{
    public class DeviceTypeVm
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        [Display(Name="Maintainer")]
        public string MaintainerName { get; set; } = string.Empty;
        
        public bool IsActive { get; set; }
    }
}
