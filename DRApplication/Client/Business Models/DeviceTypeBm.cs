using DRApplication.Shared.Models.DeviceModels;

namespace DRApplication.Client.Business_Models;

public class DeviceTypeBm
{
    #region -- database properties --

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int MaintainerId { get; set; }
    public bool IsActive { get; set; }

    #endregion

    #region -- virtual properites --

    public MaintainerBm Maintainer { get; set; } = new();

    #endregion

}
