using Microsoft.AspNetCore.Components;
namespace DRApplication.Client.Controls.Configurations;

public partial class LoadLabel
{
    [Parameter]
    public int LoadId { get; set; }

    string _loadName { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var load = await manager.GetByIdAsync(LoadId);
        _loadName = load.Name;
    }
}
