using DRApplication.Client.Interfaces;
using DRApplication.Client.ViewModels;
using DRApplication.Shared.Models;
using DRApplication.Shared.Requests;

namespace DRApplication.Client.Services;

public class SoftwareService : ISoftwareService
{

    #region ---Fields and Constructor ---

    private readonly IManagerService _managerService;
    private readonly IMapperService _mapperService;
    private readonly ILoadHelpers _loadHelpers;

    public SoftwareService(IManagerService managerService, IMapperService mapperService, ILoadHelpers loadHelpers)
    {
        _managerService = managerService;
        _mapperService = mapperService;
        _loadHelpers = loadHelpers;
    }

    #endregion

    public async Task<SoftwareSystemVm> GetSoftwareSystemVmById(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc",
            Query = $"SELECT s.Id, s.Name, s.HardwareConfigId, h.Name[HardwareConfig] " +
                    $"FROM SoftwareSystems s " +
                    $"INNER JOIN HardwareConfigs h ON h.Id = s.HardwareConfigId " +
                    $"WHERE s.Id = @softwareSystemId",
            Parameters = new Dictionary<string, int> { { "softwareSystemId", id } }
        };
        return await _managerService.SoftwareSystemVmManager().GetByIdAsync(id, adhocRequest);
    }
    public async Task<SoftwareVersionVm> GetSoftwareVersionVmById(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc",
            Query = $"SELECT s.Id, s.Name, s.SoftwareSystemId, s.VersionDate " +
                        $"FROM SoftwareVersions s " +
                        $"WHERE s.Id = @softwareVersionId ",
            Parameters = new Dictionary<string, int> { { "softwareVersionId", id } }
        };
        return await _managerService.SoftwareVersionVmManager().GetByIdAsync(id, adhocRequest);
    }
    public async Task<IEnumerable<SoftwareSystemVm>> GetSoftwareSystemVmsByHardwareConfigId(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc/listofvms",
            Query = $"SELECT s.Id, s.Name, s.HardwareConfigId, h.Name[HardwareConfig] " +
                        $"FROM SoftwareSystems s " +
                        $"INNER JOIN HardwareConfigs h ON h.Id = s.HardwareConfigId " +
                        $"WHERE s.HardwareConfigId = @hardwareConfigId ",
            Parameters = new Dictionary<string, int> { { "hardwareConfigId", id } }
        };
        return await _managerService.SoftwareSystemVmManager().Get(adhocRequest);
    }
    public async Task<IEnumerable<SoftwareVersionVm>> GetSoftwareVersionVmsBySoftwareSystemId(int id)
    {
        AdhocRequest adhocRequest = new AdhocRequest
        {
            Url = "adhoc/listofvms",
            Query = $"SELECT s.Id, s.Name, s.SoftwareSystemId, s.VersionDate " +
                        $"FROM SoftwareVersions s " +
                        $"WHERE s.SoftwareSystemId = @softwareSystemId ",
            Parameters = new Dictionary<string, int> { { "softwareSystemId", id } }
        };
        return await _managerService.SoftwareVersionVmManager().Get(adhocRequest);
    }

}