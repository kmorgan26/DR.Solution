﻿using DRApplication.Client.ViewModels;
using Microsoft.AspNetCore.Components;

namespace DRApplication.Client.Services
{
    public class AppState
    {
        public int HardwareConfigId { get; private set; } = 0;

        public int DeviceTypeId { get; private set; } = 0;

        public DeviceTypeVm DeviceTypeVm { get; private set; } = new();

        public IEnumerable<DeviceTypeVm> DeviceTypeVms { get; private set; } = new List<DeviceTypeVm>();

        public IEnumerable<HardwareConfigVm> HardwareConfigVms { get; private set; } = new List<HardwareConfigVm>();

        public HardwareConfigVm CurrentHardwareConfigVm { get; private set; } = new();

        public SoftwareSystemVm CurrentSoftwareSystemVm { get; private set; } = new();

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

        public void UpdateDeviceTypeVm(ComponentBase Source, DeviceTypeVm Model)
        {
            this.DeviceTypeVm = Model;
            NotifyStateChanged(Source, "DeviceTypeVm");
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
