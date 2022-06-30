using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
namespace DRApplication.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class DeviceController : ControllerBase
{
    DapperRepository<Device> _manager;

    public DeviceController(DapperRepository<Device> manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<ActionResult<APIListOfEntityResponse<Device>>> Get()
    {
        try
        {
            var result = await _manager.GetAllAsync();
            return Ok(new APIListOfEntityResponse<Device>()
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
    
    [HttpPost("getwithfilter")]
    public async Task<ActionResult<PagedResponse<Device>>> GetWithFilter([FromBody] QueryFilter<Device> Filter)
    {
        try
        {
            var result = await _manager.GetAsync(Filter);

            var response = new PagedResponse<Device>()
            {
                Success = true,
                Data = result.Data,
                TotalRecords = result.TotalRecords,
                PageSize = result.PageSize,
                TotalPages = result.TotalPages,
                PageNumber = result.PageNumber,
                PreviousPage = result.PreviousPage,
                NextPage = result.NextPage
            };

            return Ok(response);

        }
        catch (Exception ex)
        {
            // log exception here
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }
    
    [HttpGet("{Id}")]
    public async Task<ActionResult<APIEntityResponse<Device>>> GetById(int Id)
    {
        try
        {
            var result = await _manager.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(new APIEntityResponse<Device>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Device>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Device Not Found" },
                    Data = new Device() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<Device>>> Insert([FromBody] Device Device)
    {
        try
        {
            Device.Id = 0; // Make sure you do this!
            var result = await _manager.InsertAsync(Device);

            if (result != null)
            {
                return Ok(new APIEntityResponse<Device>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Device>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Device after adding it." },
                    Data = new Device() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<Device>>> Update([FromBody] Device Device)
    {
        try
        {
            var result = await _manager.UpdateAsync(Device);
            if (result != null)
            {
                return Ok(new APIEntityResponse<Device>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Device>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Device after updating it." },
                    Data = new Device() { Id = 0 }
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
