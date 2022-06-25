﻿using DRApplication.Client.Interfaces;
using DRApplication.Client.Services;

namespace DRApplication.Client.Helpers;

public class PlatformHelpers
{
    private readonly ManagerService _managerService;

    public PlatformHelpers(ManagerService managerService)
    {
        _managerService = managerService;
    }
    public async Task<string> GetDeviceTypeNameFromDeviceTypeId(int id)
    {
        var deviceType = await _managerService.DeviceTypeManager().GetByIdAsync(id);
        return deviceType.Name;
    }
}
