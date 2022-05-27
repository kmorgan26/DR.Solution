using DRApplication.Client.Services;
using DRApplication.Client.ViewModels;

namespace DRApplication.Client.Controls.Configurations
{
    public partial class SoftwareVersionComponent
    {
        IEnumerable<SoftwareVersionVm> _softwareVersionVms;
        protected override async Task OnInitializedAsync()
        {
            var items = await manager.GetAllAsync();
            _softwareVersionVms = Mapping.Mapper.Map<List<SoftwareVersionVm>>(items);
        }
    }
}