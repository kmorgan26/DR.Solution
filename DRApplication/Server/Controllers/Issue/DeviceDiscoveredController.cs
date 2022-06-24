using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
namespace DRApplication.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class DeviceDiscoveredController : ControllerBase
{
    DapperRepository<DeviceDiscovered> _manager;

    public DeviceDiscoveredController(DapperRepository<DeviceDiscovered> manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<ActionResult<APIListOfEntityResponse<DeviceDiscovered>>> Get()
    {
        try
        {
            var result = await _manager.GetAllAsync();
            return Ok(new APIListOfEntityResponse<DeviceDiscovered>()
            {
                Success = true,
                Data = result
            });
        }
        catch (Exception ex)
        {
            // log exception here
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<APIEntityResponse<DeviceDiscovered>>> GetById(int Id)
    {
        try
        {
            var result = await _manager.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(new APIEntityResponse<DeviceDiscovered>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<DeviceDiscovered>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "DeviceDiscovered Not Found" },
                    Data = new DeviceDiscovered() { Id = 0 }
                });
            }
        }
        catch (Exception ex)
        {
            // log exception here
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<ActionResult<APIEntityResponse<DeviceDiscovered>>> Insert([FromBody] DeviceDiscovered DeviceDiscovered)
    {
        try
        {
            DeviceDiscovered.Id = 0; // Make sure you do this!
            var result = await _manager.InsertAsync(DeviceDiscovered);

            if (result != null)
            {
                return Ok(new APIEntityResponse<DeviceDiscovered>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<DeviceDiscovered>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find DeviceDiscovered after adding it." },
                    Data = new DeviceDiscovered() { Id = 0 }
                });
            }
        }
        catch (Exception ex)
        {
            // log exception here
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPut]
    public async Task<ActionResult<APIEntityResponse<DeviceDiscovered>>> Update([FromBody] DeviceDiscovered DeviceDiscovered)
    {
        try
        {
            var result = await _manager.UpdateAsync(DeviceDiscovered);
            if (result != null)
            {
                return Ok(new APIEntityResponse<DeviceDiscovered>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<DeviceDiscovered>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find DeviceDiscovered after updating it." },
                    Data = new DeviceDiscovered() { Id = 0 }
                });
            }
        }
        catch (Exception ex)
        {
            // log exception here
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<bool>> Delete(int Id)
    {
        try
        {
            return await _manager.DeleteByIdAsync(Id);
        }
        catch (Exception ex)
        {
            // log exception here
            var msg = ex.Message;
            return StatusCode(500);
        }
    }
}
