using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
namespace DRApplication.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class DrController : ControllerBase
{
    DapperRepository<Dr> _manager;

    public DrController(DapperRepository<Dr> manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<ActionResult<APIListOfEntityResponse<Dr>>> Get()
    {
        try
        {
            var result = await _manager.GetAllAsync();
            return Ok(new APIListOfEntityResponse<Dr>()
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
    public async Task<ActionResult<PagedResponse<Dr>>> GetWithFilter([FromBody] QueryFilter<Dr> Filter)
    {
        try
        {
            var result = await _manager.GetAsync(Filter);

            var response = new PagedResponse<Dr>()
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
    public async Task<ActionResult<APIEntityResponse<Dr>>> GetById(int Id)
    {
        try
        {
            var result = await _manager.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(new APIEntityResponse<Dr>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Dr>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Dr Not Found" },
                    Data = new Dr() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<Dr>>> Insert([FromBody] Dr Dr)
    {
        try
        {
            Dr.Id = 0; // Make sure you do this!
            var result = await _manager.InsertAsync(Dr);

            if (result != null)
            {
                return Ok(new APIEntityResponse<Dr>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Dr>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Dr after adding it." },
                    Data = new Dr() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<Dr>>> Update([FromBody] Dr Dr)
    {
        try
        {
            var result = await _manager.UpdateAsync(Dr);
            if (result != null)
            {
                return Ok(new APIEntityResponse<Dr>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Dr>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Dr after updating it." },
                    Data = new Dr() { Id = 0 }
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
