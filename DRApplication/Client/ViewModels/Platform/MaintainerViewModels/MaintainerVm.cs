namespace DRApplication.Client.ViewModels;

public class MaintainerVm : IMaintainerViewModel
{
    public int Id { get; set; }

    public string Maintainer { get; set; } = null!;
    
}
