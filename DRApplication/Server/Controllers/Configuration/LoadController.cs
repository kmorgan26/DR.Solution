using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
namespace DRApplication.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class LoadController : ControllerBase
{
    DapperRepository<Load> _manager;

    public LoadController(DapperRepository<Load> manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<ActionResult<APIListOfEntityResponse<Load>>> Get()
    {
        try
        {
            var result = await _manager.GetAllAsync();
            return Ok(new APIListOfEntityResponse<Load>()
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
    public async Task<ActionResult<PagedResponse<Load>>> GetWithFilter([FromBody] QueryFilter<Load> Filter)
    {
        try
        {
            var result = await _manager.GetAsync(Filter);
            return Ok(new PagedResponse<Load>()
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
    public async Task<ActionResult<APIEntityResponse<Load>>> GetById(int Id)
    {
        try
        {
            var result = await _manager.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(new APIEntityResponse<Load>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Load>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Load Not Found" },
                    Data = new Load() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<Load>>> Insert([FromBody] Load Load)
    {
        try
        {
            Load.Id = 0; // Make sure you do this!
            var result = await _manager.InsertAsync(Load);

            if (result != null)
            {
                return Ok(new APIEntityResponse<Load>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Load>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Load after adding it." },
                    Data = new Load() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<Load>>> Update([FromBody] Load Load)
    {
        try
        {
            var result = await _manager.UpdateAsync(Load);
            if (result != null)
            {
                return Ok(new APIEntityResponse<Load>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Load>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Load after updating it." },
                    Data = new Load() { Id = 0 }
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