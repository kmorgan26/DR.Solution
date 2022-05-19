using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Business_Models
{
    public class MaintainerBm : Maintainer
    {
        private string? maintainer;

        public string? Maintainer
        {
            get { return this.Name; }
            set { maintainer = value; }
        }

    }
}
