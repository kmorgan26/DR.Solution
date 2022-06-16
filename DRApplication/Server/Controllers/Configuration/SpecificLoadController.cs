using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
namespace DRApplication.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class SpecificLoadController : ControllerBase
{
    DapperRepository<SpecificLoad> _manager;

    public SpecificLoadController(DapperRepository<SpecificLoad> manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<ActionResult<APIListOfEntityResponse<SpecificLoad>>> Get()
    {
        try
        {
            var result = await _manager.GetAllAsync();
            return Ok(new APIListOfEntityResponse<SpecificLoad>()
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
    public async Task<ActionResult<PagedResponse<SpecificLoad>>> GetWithFilter([FromBody] QueryFilter<SpecificLoad> Filter)
    {
        try
        {
            var result = await _manager.GetAsync(Filter);
            return Ok(new PagedResponse<SpecificLoad>()
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
    public async Task<ActionResult<APIEntityResponse<SpecificLoad>>> GetById(int Id)
    {
        try
        {
            var result = await _manager.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(new APIEntityResponse<SpecificLoad>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<SpecificLoad>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "SpecificLoad Not Found" },
                    Data = new SpecificLoad() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<SpecificLoad>>> Insert([FromBody] SpecificLoad SpecificLoad)
    {
        try
        {
            SpecificLoad.Id = 0; // Make sure you do this!
            var result = await _manager.InsertAsync(SpecificLoad);

            if (result != null)
            {
                return Ok(new APIEntityResponse<SpecificLoad>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<SpecificLoad>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find SpecificLoad after adding it." },
                    Data = new SpecificLoad() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<SpecificLoad>>> Update([FromBody] SpecificLoad SpecificLoad)
    {
        try
        {
            var result = await _manager.UpdateAsync(SpecificLoad);
            if (result != null)
            {
                return Ok(new APIEntityResponse<SpecificLoad>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<SpecificLoad>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find SpecificLoad after updating it." },
                    Data = new SpecificLoad() { Id = 0 }
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