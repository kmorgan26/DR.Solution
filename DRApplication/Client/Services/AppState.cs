using DRApplication.Client.ViewModels;
using Microsoft.AspNetCore.Components;

namespace DRApplication.Client.Services
{
    public class AppState
    {
        #region -- single ID properties --

        public int HardwareConfigId { get; private set; } = 0;

        public int DeviceTypeId { get; private set; } = 0;

        #endregion

        #region -- single View Model Properties --

        public DeviceTypeVm DeviceTypeVm { get; private set; } = new();

        public HardwareConfigVm HardwareConfigVm { get; private set; } = new();
        
        public SoftwareSystemVm SoftwareSystemVm { get; private set; } = new();

        public SoftwareVersionVm SoftwareVersionVm { get; private set; } = new();

        public LoadVm LoadVm { get; private set; } = new();

        public VersionsLoadVm VersionsLoadVm { get; private set; } = new();

        #endregion

        #region -- View Model Collections --

        public IEnumerable<DeviceTypeVm> DeviceTypeVms { get; private set; } = new List<DeviceTypeVm>();

        public IEnumerable<HardwareConfigVm> HardwareConfigVms { get; private set; } = new List<HardwareConfigVm>();

        public IEnumerable<SoftwareSystemVm> SoftwareSystemVms { get; private set; } = new List<SoftwareSystemVm>();

        public IEnumerable<SoftwareVersionVm> SoftwareVersionVms { get; private set; } = new List<SoftwareVersionVm>();

        public IEnumerable<LoadVm> LoadVms { get; private set; } = new List<LoadVm>();

        public IEnumerable<VersionsLoadVm> VersionsLoadVms { get; private set; } = new List<VersionsLoadVm>();

        #endregion

        #region -- single ID Methods --

        public void UpdateHardwareConfigId(ComponentBase Source, int Model)
        {
            HardwareConfigId = Model;
            NotifyStateChanged(Source, "HardwareConfigId");
        }
        public void UpdateDeviceTypeId(ComponentBase Source, int Model)
        {
            DeviceTypeId = Model;
            NotifyStateChanged(Source, "DeviceTypeId");
        }

        #endregion

        #region -- View Model Collection Methods --

        public void UpdateLoadVms(ComponentBase Source, IEnumerable<LoadVm> Model)
        {
            this.LoadVms = Model;
            NotifyStateChanged(Source, "LoadVms");
        }

        public void UpdateHardwareConfigVms(ComponentBase Source, IEnumerable<HardwareConfigVm> Model)
        {
            this.HardwareConfigVms = Model;
            NotifyStateChanged(Source, "HardwareConfigVms");
        }

        public void UpdateVersionsLoadVms(ComponentBase Source, IEnumerable<VersionsLoadVm> Model)
        {
            this.VersionsLoadVms = Model;
            NotifyStateChanged(Source, "VersionsLoadVms");
        }

        public void UpdateSoftwareSystemVms(ComponentBase Source, IEnumerable<SoftwareSystemVm> Model)
        {
            this.SoftwareSystemVms = Model;
            NotifyStateChanged(Source, "SoftwareSystemVms");
        }

        public void UpdateDeviceTypeVms(ComponentBase Source, IEnumerable<DeviceTypeVm> Model)
        {
            this.DeviceTypeVms = Model;
            NotifyStateChanged(Source, "DeviceTypeVms");
        }

        public void UpdateSoftwareVersionVms(ComponentBase Source, IEnumerable<SoftwareVersionVm> Model)
        {
            this.SoftwareVersionVms = Model;
            NotifyStateChanged(Source, "SoftwareVersionVms");
        }

        #endregion

        #region -- View Model Methods --

        public void UpdateVersionsLoadVm(ComponentBase Source, VersionsLoadVm Model)
        {
            this.VersionsLoadVm = Model;
            NotifyStateChanged(Source, "VersionsLoadVm");
        }

        public void UpdateLoadVm(ComponentBase Source, LoadVm Model)
        {
            this.LoadVm = Model;
            NotifyStateChanged(Source, "LoadVm");
        }

        public void UpdateDeviceTypeVm(ComponentBase Source, DeviceTypeVm Model)
        {
            this.DeviceTypeVm = Model;
            NotifyStateChanged(Source, "DeviceTypeVm");
        }

        public void UpdateHardwareConfigVm(ComponentBase Source, HardwareConfigVm Model)
        {
            this.HardwareConfigVm = Model;
            NotifyStateChanged(Source, "HardwareConfigVm");
        }

        public void UpdateSoftwareSystemVm(ComponentBase Source, SoftwareSystemVm Model)
        {
            this.SoftwareSystemVm = Model;
            NotifyStateChanged(Source, "SoftwareSystemVm");
        }

        public void UpdateSoftwareVersionVm(ComponentBase Source, SoftwareVersionVm Model)
        {
            this.SoftwareVersionVm = Model;
            NotifyStateChanged(Source, "SoftwareVersionVm");
        }

        #endregion

        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);
    }
}
