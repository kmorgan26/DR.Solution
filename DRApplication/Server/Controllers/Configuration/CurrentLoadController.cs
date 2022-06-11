using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models.ConfigurationModels;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
namespace DRApplication.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class CurrentLoadController : ControllerBase
{
    DapperRepository<CurrentLoad> _manager;

    public CurrentLoadController(DapperRepository<CurrentLoad> manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<ActionResult<APIListOfEntityResponse<CurrentLoad>>> Get()
    {
        try
        {
            var result = await _manager.GetAllAsync();
            return Ok(new APIListOfEntityResponse<CurrentLoad>()
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
    public async Task<ActionResult<PagedResponse<CurrentLoad>>> GetWithFilter([FromBody] QueryFilter<CurrentLoad> Filter)
    {
        try
        {
            var result = await _manager.GetAsync(Filter);
            return Ok(new PagedResponse<CurrentLoad>()
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
    public async Task<ActionResult<APIEntityResponse<CurrentLoad>>> GetById(int Id)
    {
        try
        {
            var result = await _manager.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(new APIEntityResponse<CurrentLoad>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<CurrentLoad>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "CurrentLoad Not Found" },
                    Data = new CurrentLoad() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<CurrentLoad>>> Insert([FromBody] CurrentLoad CurrentLoad)
    {
        try
        {
            CurrentLoad.Id = 0; // Make sure you do this!
            var result = await _manager.InsertAsync(CurrentLoad);

            if (result != null)
            {
                return Ok(new APIEntityResponse<CurrentLoad>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<CurrentLoad>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find CurrentLoad after adding it." },
                    Data = new CurrentLoad() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<CurrentLoad>>> Update([FromBody] CurrentLoad CurrentLoad)
    {
        try
        {
            var result = await _manager.UpdateAsync(CurrentLoad);
            if (result != null)
            {
                return Ok(new APIEntityResponse<CurrentLoad>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<CurrentLoad>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find CurrentLoad after updating it." },
                    Data = new CurrentLoad() { Id = 0 }
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