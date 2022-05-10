using Microsoft.AspNetCore.Components;
namespace DRApplication.Client.Controls.Configurations;
public partial class HardwareVersionLabel
{
    [Parameter]
    public int HardwareVersionId { get; set; }

    string _hardwareVersionName { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var hardwareVersions = await manager.GetByIdAsync(HardwareVersionId);
        _hardwareVersionName = hardwareVersions.Name;
    }
}