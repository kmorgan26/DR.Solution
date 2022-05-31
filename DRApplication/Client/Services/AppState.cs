using DRApplication.Client.ViewModels;
using Microsoft.AspNetCore.Components;

namespace DRApplication.Client.Services
{
    public class AppState
    {

        public DeviceTypeVm CurrentDeviceTypeVm { get; private set; } = new();
        public IEnumerable<DeviceTypeVm> DeviceTypeVms { get; private set; } = new List<DeviceTypeVm>();

        public void UpdateDeviceTypeVms(ComponentBase Source, IEnumerable<DeviceTypeVm> Model)
        {
            this.DeviceTypeVms = Model;
            NotifyStateChanged(Source, "DeviceTypeVms");
        }

        public void UpdateCurrentDeviceTypeVm(ComponentBase Source, DeviceTypeVm Model)
        {
            this.CurrentDeviceTypeVm = Model;
            NotifyStateChanged(Source, "CurrentDeviceTypeVm");
        }

        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);
    }
}
