using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
namespace DRApplication.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class CorrectiveActionController : ControllerBase
{
    DapperRepository<CorrectiveAction> _manager;

    public CorrectiveActionController(DapperRepository<CorrectiveAction> manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<ActionResult<APIListOfEntityResponse<CorrectiveAction>>> Get()
    {
        try
        {
            var result = await _manager.GetAllAsync();
            return Ok(new APIListOfEntityResponse<CorrectiveAction>()
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
    public async Task<ActionResult<PagedResponse<CorrectiveAction>>> GetWithFilter([FromBody] QueryFilter<CorrectiveAction> Filter)
    {
        try
        {
            var result = await _manager.GetAsync(Filter);

            var response = new PagedResponse<CorrectiveAction>()
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
    public async Task<ActionResult<APIEntityResponse<CorrectiveAction>>> GetById(int Id)
    {
        try
        {
            var result = await _manager.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(new APIEntityResponse<CorrectiveAction>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<CorrectiveAction>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "CorrectiveAction Not Found" },
                    Data = new CorrectiveAction() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<CorrectiveAction>>> Insert([FromBody] CorrectiveAction CorrectiveAction)
    {
        try
        {
            CorrectiveAction.Id = 0; // Make sure you do this!
            var result = await _manager.InsertAsync(CorrectiveAction);

            if (result != null)
            {
                return Ok(new APIEntityResponse<CorrectiveAction>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<CorrectiveAction>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find CorrectiveAction after adding it." },
                    Data = new CorrectiveAction() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<CorrectiveAction>>> Update([FromBody] CorrectiveAction CorrectiveAction)
    {
        try
        {
            var result = await _manager.UpdateAsync(CorrectiveAction);
            if (result != null)
            {
                return Ok(new APIEntityResponse<CorrectiveAction>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<CorrectiveAction>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find CorrectiveAction after updating it." },
                    Data = new CorrectiveAction() { Id = 0 }
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
