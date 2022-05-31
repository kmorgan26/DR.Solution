using Microsoft.AspNetCore.Components;

namespace DRApplication.Client.Controls;

public partial class HardwareSystemLabel
{
    [Parameter]
    public int HardwareSystemId { get; set; }

    string _hardwareSystemName { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var hardwareSystems = await manager.GetByIdAsync(HardwareSystemId);
        _hardwareSystemName = hardwareSystems.Name;
    }
}