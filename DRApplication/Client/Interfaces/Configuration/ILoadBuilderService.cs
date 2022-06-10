﻿using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models.ConfigurationModels;

namespace DRApplication.Client.Interfaces;

public interface ILoadBuilderService
{
    Task<IEnumerable<LoadVm>> GetLoadVmByDeviceTypeId(int id);
    
    Task<IEnumerable<VersionsLoadVm>> GetVersionsLoadVmsByLoadId(int id);

    Task<IEnumerable<CurrentLoadVm>> GetCurrentLoadVmByDeviceTypeId(int id);

    Task<IEnumerable<CurrentLoadVm>> MapCurrentLoadsToCurrentLoadVms(IEnumerable<CurrentLoad> currentLoads);
    
    Task AddSoftwareVersionToLoad();
}