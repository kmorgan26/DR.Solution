using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Platform;
using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Controls.Platforms
{
    public partial class MaintainerTable
    {
        [Parameter]
        public IEnumerable<MaintainerVm>? _viewModels { get; set; }

        private async Task UpdateRowItem(object e)
        {
            var viewModel = (MaintainerVm)e;
            var model = Mapping.Mapper.Map<Maintainer>(viewModel);
            await _db.UpdateAsync(model);
        }
    }
}