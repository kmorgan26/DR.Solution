using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models.ConfigurationModels;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
namespace DRApplication.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class SoftwareVersionController : ControllerBase
{
    DapperRepository<SoftwareVersion> _manager;

    public SoftwareVersionController(DapperRepository<SoftwareVersion> manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<ActionResult<APIListOfEntityResponse<SoftwareVersion>>> Get()
    {
        try
        {
            var result = await _manager.GetAllAsync();
            return Ok(new APIListOfEntityResponse<SoftwareVersion>()
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
    public async Task<ActionResult<APIListOfEntityResponse<SoftwareVersion>>> GetWithFilter([FromBody] QueryFilter<SoftwareVersion> Filter)
    {
        try
        {
            var result = await _manager.GetAsync(Filter);
            return Ok(new APIListOfEntityResponse<SoftwareVersion>()
            {
                Success = true,
                Data = result.ToList()
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
    public async Task<ActionResult<APIEntityResponse<SoftwareVersion>>> GetById(int Id)
    {
        try
        {
            var result = await _manager.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(new APIEntityResponse<SoftwareVersion>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<SoftwareVersion>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Software Version Not Found" },
                    Data = new SoftwareVersion() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<SoftwareVersion>>> Insert([FromBody] SoftwareVersion SoftwareVersion)
    {
        try
        {
            SoftwareVersion.Id = 0; // Make sure you do this!
            var result = await _manager.InsertAsync(SoftwareVersion);

            if (result != null)
            {
                return Ok(new APIEntityResponse<SoftwareVersion>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<SoftwareVersion>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Software Version after adding it." },
                    Data = new SoftwareVersion() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<SoftwareVersion>>> Update([FromBody] SoftwareVersion SoftwareVersion)
    {
        try
        {
            var result = await _manager.UpdateAsync(SoftwareVersion);
            if (result != null)
            {
                return Ok(new APIEntityResponse<SoftwareVersion>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<SoftwareVersion>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Software Version after updating it." },
                    Data = new SoftwareVersion() { Id = 0 }
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
