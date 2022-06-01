using DRApplication.Client.ViewModels;
using Microsoft.AspNetCore.Components;

namespace DRApplication.Client.Services
{
    public class AppState
    {

        public DeviceTypeVm CurrentDeviceTypeVm { get; private set; } = new();

        public IEnumerable<DeviceTypeVm> DeviceTypeVms { get; private set; } = new List<DeviceTypeVm>();

        public IEnumerable<HardwareConfigVm> HardwareConfigVms { get; private set; } = new List<HardwareConfigVm>();

        public HardwareConfigVm CurrentHardwareConfigVm { get; private set; } = new();

        public SoftwareSystemVm CurrentSoftwareSystemVm { get; private set; } = new();

        public void UpdateHardwareConfigVms(ComponentBase Source, IEnumerable<HardwareConfigVm> Model)
        {
            this.HardwareConfigVms = Model;
            NotifyStateChanged(Source, "HardwareConfigVms");
        }

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

        public void UpdateCurrentHardwareConfigVm(ComponentBase Source, HardwareConfigVm Model)
        {
            this.CurrentHardwareConfigVm = Model;
            NotifyStateChanged(Source, "CurrentHardwareConfigVm");
        }

        public void UpdateCurrentSoftwareSystemVm(ComponentBase Source, SoftwareSystemVm Model)
        {
            this.CurrentSoftwareSystemVm = Model;
            NotifyStateChanged(Source, "CurrentSoftwareSystemVm");
        }

        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);
    }
}
