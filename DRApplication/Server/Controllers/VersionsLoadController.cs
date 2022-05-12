using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models.ConfigurationModels;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
namespace DRApplication.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class VersionsLoadController : ControllerBase
{
    DapperRepository<VersionsLoad> _manager;

    public VersionsLoadController(DapperRepository<VersionsLoad> manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<ActionResult<APIListOfEntityResponse<VersionsLoad>>> Get()
    {
        try
        {
            var result = await _manager.GetAllAsync();
            return Ok(new APIListOfEntityResponse<VersionsLoad>()
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
    public async Task<ActionResult<PagedResponse<VersionsLoad>>> GetWithFilter([FromBody] QueryFilter<VersionsLoad> Filter)
    {
        try
        {
            var result = await _manager.GetAsync(Filter);
            return Ok(new PagedResponse<VersionsLoad>()
            {
                Success = true,
                Data = result.Data
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
    public async Task<ActionResult<APIEntityResponse<VersionsLoad>>> GetById(int Id)
    {
        try
        {
            var result = await _manager.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(new APIEntityResponse<VersionsLoad>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<VersionsLoad>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Software Version/Load Not Found" },
                    Data = new VersionsLoad() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<VersionsLoad>>> Insert([FromBody] VersionsLoad VersionsLoad)
    {
        try
        {
            VersionsLoad.Id = 0; // Make sure you do this!
            var result = await _manager.InsertAsync(VersionsLoad);

            if (result != null)
            {
                return Ok(new APIEntityResponse<VersionsLoad>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<VersionsLoad>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Software Version/Load after adding it." },
                    Data = new VersionsLoad() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<VersionsLoad>>> Update([FromBody] VersionsLoad VersionsLoad)
    {
        try
        {
            var result = await _manager.UpdateAsync(VersionsLoad);
            if (result != null)
            {
                return Ok(new APIEntityResponse<VersionsLoad>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<VersionsLoad>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Software Version/Load after updating it." },
                    Data = new VersionsLoad() { Id = 0 }
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
