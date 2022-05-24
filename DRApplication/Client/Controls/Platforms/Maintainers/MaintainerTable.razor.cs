using Microsoft.AspNetCore.Components;
using DRApplication.Client.Services;
using DRApplication.Client.ViewModels.Platform;
using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Controls.Platforms
{
    public partial class MaintainerTable
    {
        bool _isBusy;

        [Parameter]
        public IEnumerable<MaintainerVm>? MaintainerVms { get; set; }

        private async Task UpdateRowItem(object e)
        {
            var viewModel = (MaintainerVm)e;
            var model = Mapping.Mapper.Map<Maintainer>(viewModel);
            await _db.UpdateAsync(model);
        }

        protected override async Task OnInitializedAsync()
        {
            _isBusy = true;
            var models = await _db.GetAllAsync();
            MaintainerVms = Mapping.Mapper.Map<IEnumerable<MaintainerVm>>(models);
            _isBusy = false;
        }
    }
}