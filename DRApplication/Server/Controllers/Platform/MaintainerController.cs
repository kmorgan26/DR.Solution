using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
namespace DRApplication.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class MaintainerController : ControllerBase
{
    DapperRepository<Maintainer> _manager;

    public MaintainerController(DapperRepository<Maintainer> manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<ActionResult<APIListOfEntityResponse<Maintainer>>> Get()
    {
        try
        {
            var result = await _manager.GetAllAsync();
            return Ok(new APIListOfEntityResponse<Maintainer>()
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
    public async Task<ActionResult<PagedResponse<Maintainer>>> GetWithFilter([FromBody] QueryFilter<Maintainer> Filter)
    {
        try
        {
            var result = await _manager.GetAsync(Filter);
            return Ok(new PagedResponse<Maintainer>()
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
    public async Task<ActionResult<APIEntityResponse<Maintainer>>> GetById(int Id)
    {
        try
        {
            var result = await _manager.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(new APIEntityResponse<Maintainer>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Maintainer>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Customer Not Found" },
                    Data = new Maintainer() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<Maintainer>>> Insert([FromBody] Maintainer Maintainer)
    {
        try
        {
            Maintainer.Id = 0; // Make sure you do this!
            var result = await _manager.InsertAsync(Maintainer);

            if (result != null)
            {
                return Ok(new APIEntityResponse<Maintainer>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Maintainer>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Device Type after adding it." },
                    Data = new Maintainer() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<Maintainer>>> Update([FromBody] Maintainer Maintainer)
    {
        try
        {
            var result = await _manager.UpdateAsync(Maintainer);
            if (result != null)
            {
                return Ok(new APIEntityResponse<Maintainer>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Maintainer>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find customer after updating it." },
                    Data = new Maintainer() { Id = 0 }
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
