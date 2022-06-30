using DRApplication.Server.Data;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Models;
using DRApplication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
namespace DRApplication.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class IssueController : ControllerBase
{
    DapperRepository<Issue> _manager;

    public IssueController(DapperRepository<Issue> manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<ActionResult<APIListOfEntityResponse<Issue>>> Get()
    {
        try
        {
            var result = await _manager.GetAllAsync();
            return Ok(new APIListOfEntityResponse<Issue>()
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
    public async Task<ActionResult<PagedResponse<Issue>>> GetWithFilter([FromBody] QueryFilter<Issue> Filter)
    {
        try
        {
            var result = await _manager.GetAsync(Filter);

            var response = new PagedResponse<Issue>()
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
    public async Task<ActionResult<APIEntityResponse<Issue>>> GetById(int Id)
    {
        try
        {
            var result = await _manager.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(new APIEntityResponse<Issue>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Issue>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Issue Not Found" },
                    Data = new Issue() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<Issue>>> Insert([FromBody] Issue Issue)
    {
        try
        {
            Issue.Id = 0; // Make sure you do this!
            var result = await _manager.InsertAsync(Issue);

            if (result != null)
            {
                return Ok(new APIEntityResponse<Issue>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Issue>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Issue after adding it." },
                    Data = new Issue() { Id = 0 }
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
    public async Task<ActionResult<APIEntityResponse<Issue>>> Update([FromBody] Issue Issue)
    {
        try
        {
            var result = await _manager.UpdateAsync(Issue);
            if (result != null)
            {
                return Ok(new APIEntityResponse<Issue>()
                {
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return Ok(new APIEntityResponse<Issue>()
                {
                    Success = false,
                    ErrorMessages = new List<string>() { "Could not find Issue after updating it." },
                    Data = new Issue() { Id = 0 }
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
