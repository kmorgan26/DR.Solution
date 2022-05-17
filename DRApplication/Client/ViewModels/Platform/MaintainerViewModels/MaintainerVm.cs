using DRApplication.Client.ViewModels.Platform.MaintainerViewModels;
using System.ComponentModel.DataAnnotations;

namespace DRApplication.Client.ViewModels.Platform;
public class MaintainerVm : IMaintainerViewModel
{
    public int Id { get; set; }

    public string Maintainer { get; set; } = null!;
    
}
