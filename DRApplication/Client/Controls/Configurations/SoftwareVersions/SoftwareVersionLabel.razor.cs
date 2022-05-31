using Microsoft.AspNetCore.Components;
namespace DRApplication.Client.Controls;
public partial class SoftwareVersionLabel
{
    [Parameter]
    public int SoftwareVersionId { get; set; }

    string _softwareVersionName { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var softwareVersions = await manager.GetByIdAsync(SoftwareVersionId);
        _softwareVersionName = softwareVersions.Name;
    }
}