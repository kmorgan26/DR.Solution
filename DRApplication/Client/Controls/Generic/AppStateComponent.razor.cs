using Microsoft.AspNetCore.Components;

namespace DRApplication.Client.Controls.Generic
{
    public partial class AppStateComponent
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        private int? hardwareConfigId;
        public int? HardwareConfigId
        {
            get
            {
                return hardwareConfigId;
            }

            set
            {
                hardwareConfigId = value;
                StateHasChanged();
            }
        }

        private int? hardwareVersionId;
        public int? HardwareVersionId
        {
            get
            {
                return hardwareVersionId;
            }

            set
            {
                hardwareVersionId = value;
                StateHasChanged();
            }
        }

        private int? hardwareSystemId;
        public int? HardwareSystemId
        {
            get
            {
                return hardwareSystemId;
            }

            set
            {
                hardwareSystemId = value;
                StateHasChanged();
            }
        }

        private int? softwareSystemId;
        public int? SoftwareSystemId
        {
            get
            {
                return softwareSystemId;
            }

            set
            {
                softwareSystemId = value;
                StateHasChanged();
            }
        }

        private int? softwareVersionId;
        public int? SoftwareVersionId
        {
            get
            {
                return softwareVersionId;
            }

            set
            {
                softwareVersionId = value;
                StateHasChanged();
            }
        }

        private int? deviceTypeId;
        public int? DeviceTypeId
        {
            get
            {
                return deviceTypeId;
            }

            set
            {
                deviceTypeId = value;
                StateHasChanged();
            }
        }

        private int? maintainerId;
        public int? MaintainerId
        {
            get
            {
                return maintainerId;
            }

            set
            {
                maintainerId = value;
                StateHasChanged();
            }
        }

        private bool? isSet;
        public bool? IsSet
        {
            get
            {
                return isSet;
            }

            set
            {
                isSet = value;
                StateHasChanged();
            }
        }

        public void AppStateReset()
        {
            this.IsSet = false;
            StateHasChanged();
        }
    }
}