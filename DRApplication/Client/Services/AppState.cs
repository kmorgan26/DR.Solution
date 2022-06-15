using DRApplication.Client.ViewModels;
using Microsoft.AspNetCore.Components;

namespace DRApplication.Client.Services
{
    public class AppState
    {
        #region -- View Model Properties --

        public CurrentLoadVm CurrentLoadVm { get; private set; } = new();

        public HardwareSystemVm HardwareSystemVm { get; private set; } = new();

        public HardwareVersionVm HardwareVersionVm { get; private set; } = new();

        public HardwareVersionsConfigVm HardwareVersionsConfigVm { get; private set; } = new();
        
        public HardwareConfigVm HardwareConfigVm { get; private set; } = new();

        public SoftwareSystemVm SoftwareSystemVm { get; private set; } = new();

        public SoftwareVersionVm SoftwareVersionVm { get; private set; } = new();

        public LoadVm LoadVm { get; private set; } = new();

        public VersionsLoadVm VersionsLoadVm { get; private set; } = new();

        public DeviceTypeVm DeviceTypeVm { get; private set; } = new();

        public DeviceVm DeviceVm { get; private set; } = new();

        public MaintainerVm MaintainerVm { get; private set; } = new();

        #endregion

        #region -- View Model Collections --
        public IEnumerable<CurrentLoadVm> CurrentLoadVms { get; private set; } = new List<CurrentLoadVm>();
        
        public IEnumerable<HardwareSystemVm> HardwareSystemVms { get; private set; } = new List<HardwareSystemVm>();

        public IEnumerable<HardwareVersionVm> HardwareVersionVms { get; private set; } = new List<HardwareVersionVm>();

        public IEnumerable<HardwareVersionsConfigVm> HardwareVersionsConfigVms { get; private set; } = new List<HardwareVersionsConfigVm>();

        public IEnumerable<HardwareConfigVm> HardwareConfigVms { get; private set; } = new List<HardwareConfigVm>();

        public IEnumerable<SoftwareSystemVm> SoftwareSystemVms { get; private set; } = new List<SoftwareSystemVm>();
        
        public IEnumerable<SoftwareVersionVm> SoftwareVersionVms { get; private set; } = new List<SoftwareVersionVm>();
        
        public IEnumerable<LoadVm> LoadVms { get; private set; } = new List<LoadVm>();
        
        public IEnumerable<VersionsLoadVm> VersionsLoadVms { get; private set; } = new List<VersionsLoadVm>();
        
        public IEnumerable<DeviceTypeVm> DeviceTypeVms { get; private set; } = new List<DeviceTypeVm>();

        public IEnumerable<DeviceVm> DeviceVms { get; private set; } = new List<DeviceVm>();

        public IEnumerable<MaintainerVm> MaintainerVms { get; private set; } = new List<MaintainerVm>();

        #endregion

        #region -- single ID Methods --

        //public void UpdateHardwareConfigId(ComponentBase Source, int Model)
        //{
        //    HardwareConfigId = Model;
        //    NotifyStateChanged(Source, "HardwareConfigId");
        //}
        //public void UpdateDeviceTypeId(ComponentBase Source, int Model)
        //{
        //    DeviceTypeId = Model;
        //    NotifyStateChanged(Source, "DeviceTypeId");
        //}

        #endregion

        #region -- View Model Methods --

        public void UpdateCurrentLoadVm(ComponentBase Source, CurrentLoadVm Model)
        {
            this.CurrentLoadVm = Model;
            NotifyStateChanged(Source, "CurrentLoadVm");
        }
        public void UpdateHardwareSystemVm(ComponentBase Source, HardwareSystemVm Model)
        {
            this.HardwareSystemVm = Model;
            NotifyStateChanged(Source, "HardwareSystemVm");
        }
        public void UpdateHardwareVersionVm(ComponentBase Source, HardwareVersionVm Model)
        {
            this.HardwareVersionVm = Model;
            NotifyStateChanged(Source, "HardwareVersionVm");
        }
        public void UpdateHardwareVersionsConfigVm(ComponentBase Source, HardwareVersionsConfigVm Model)
        {
            this.HardwareVersionsConfigVm = Model;
            NotifyStateChanged(Source, "HardwareVersionsConfigVm");
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
        public void UpdateDeviceVm(ComponentBase Source, DeviceVm Model)
        {
            this.DeviceVm = Model;
            NotifyStateChanged(Source, "DeviceVm");
        }
        public void UpdateMaintainerVm(ComponentBase Source, MaintainerVm Model)
        {
            this.MaintainerVm = Model;
            NotifyStateChanged(Source, "MaintainerVm");
        }

        #endregion

        #region -- View Model Collection Methods --

        public void UpdateCurrentLoadVms(ComponentBase Source, IEnumerable<CurrentLoadVm> Model)
        {
            this.CurrentLoadVms = Model;
            NotifyStateChanged(Source, "CurrentLoadVms");
        }
        public void UpdateHardwareSystemVms(ComponentBase Source, IEnumerable<HardwareSystemVm> Model)
        {
            this.HardwareSystemVms = Model;
            NotifyStateChanged(Source, "HardwareSystemVms");
        }
        public void UpdateHardwareVersionVms(ComponentBase Source, IEnumerable<HardwareVersionVm> Model)
        {
            this.HardwareVersionVms = Model;
            NotifyStateChanged(Source, "HardwareVersionVms");
        }
        public void UpdateHardwareVersionsConfigVms(ComponentBase Source, IEnumerable<HardwareVersionsConfigVm> Model)
        {
            this.HardwareVersionsConfigVms = Model;
            NotifyStateChanged(Source, "HardwareVersionsConfigVms");
        }
        public void UpdateHardwareConfigVms(ComponentBase Source, IEnumerable<HardwareConfigVm> Model)
        {
            this.HardwareConfigVms = Model;
            NotifyStateChanged(Source, "HardwareConfigVms");
        }
        public void UpdateSoftwareSystemVms(ComponentBase Source, IEnumerable<SoftwareSystemVm> Model)
        {
            this.SoftwareSystemVms = Model;
            NotifyStateChanged(Source, "SoftwareSystemVms");
        }
        public void UpdateSoftwareVersionVms(ComponentBase Source, IEnumerable<SoftwareVersionVm> Model)
        {
            this.SoftwareVersionVms = Model;
            NotifyStateChanged(Source, "SoftwareVersionVms");
        }
        public void UpdateVersionsLoadVms(ComponentBase Source, IEnumerable<VersionsLoadVm> Model)
        {
            this.VersionsLoadVms = Model;
            NotifyStateChanged(Source, "VersionsLoadVms");
        }
        public void UpdateLoadVms(ComponentBase Source, IEnumerable<LoadVm> Model)
        {
            this.LoadVms = Model;
            NotifyStateChanged(Source, "LoadVms");
        }
        public void UpdateDeviceTypeVms(ComponentBase Source, IEnumerable<DeviceTypeVm> Model)
        {
            this.DeviceTypeVms = Model;
            NotifyStateChanged(Source, "DeviceTypeVms");
        }
        public void UpdateDeviceVms(ComponentBase Source, IEnumerable<DeviceVm> Model)
        {
            this.DeviceVms = Model;
            NotifyStateChanged(Source, "DeviceVms");
        }
        public void UpdateMaintainerVms(ComponentBase Source, IEnumerable<MaintainerVm> Model)
        {
            this.MaintainerVms = Model;
            NotifyStateChanged(Source, "MaintainerVms");
        }
        #endregion

        public event Action<ComponentBase, string> StateChanged;

        private void NotifyStateChanged(ComponentBase Source, string Property) => StateChanged?.Invoke(Source, Property);
    }
}