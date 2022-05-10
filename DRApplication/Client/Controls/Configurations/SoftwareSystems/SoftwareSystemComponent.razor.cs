using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Configuration;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class SoftwareSystemComponent
    {
        List<SoftwareSystemVm> _softwareSystemVms = new();
        protected override async Task OnInitializedAsync()
        {
            var items = await manager.GetAllAsync();
            _softwareSystemVms = Mapping.Mapper.Map<List<SoftwareSystemVm>>(items);
        }
    }
}